    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                // identify the path to the xsd
                const string xsdFileName = @"schema.xsd";
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var xsdPath = Path.Combine(path, xsdFileName);
                // load the xsd
                XmlSchema xsd;
                using (var stream = new FileStream(xsdPath, FileMode.Open, FileAccess.Read))
                {
                    xsd = XmlSchema.Read(stream, null);
                }
                var xsds = new XmlSchemas();
                xsds.Add(xsd);
                xsds.Compile(null, true);
                var schemaImporter = new XmlSchemaImporter(xsds);
                // create the codedom
                var codeNamespace = new CodeNamespace("Generated");
                var codeExporter = new XmlCodeExporter(codeNamespace);
                var maps = new List<XmlTypeMapping>();
                foreach (XmlSchemaType schemaType in xsd.SchemaTypes.Values)
                {
                    maps.Add(schemaImporter.ImportSchemaType(schemaType.QualifiedName));
                }
                foreach (XmlSchemaElement schemaElement in xsd.Elements.Values)
                {
                    maps.Add(schemaImporter.ImportTypeMapping(schemaElement.QualifiedName));
                }
                foreach (var map in maps)
                {
                    codeExporter.ExportTypeMapping(map);
                }
                PostProcess(codeNamespace);
                // Check for invalid characters in identifiers
                CodeGenerator.ValidateIdentifiers(codeNamespace);
                // output the C# code
                var codeProvider = new CSharpCodeProvider();
                using (var writer = new StringWriter())
                {
                    codeProvider.GenerateCodeFromNamespace(codeNamespace, writer, new CodeGeneratorOptions());
                    Console.WriteLine(writer.GetStringBuilder().ToString());
                }
            }
            // For each class declaration, 
            // adds interface declaration, makes that class inherit from that interface,
            // and adds COM interop stuff
            private static void PostProcess(CodeNamespace codeNamespace)
            {
                var codeTypeDeclarations = new List<CodeTypeDeclaration>();
                foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
                {
                    // mark class as com visible
                    AddClassInterfaceNone(codeType.CustomAttributes);
                    AddComVisibleTrue(codeType.CustomAttributes);
                    // create new interface
                    var itf = new CodeTypeDeclaration
                    {
                        Name = string.Format("I{0}", codeType.Name),
                        IsInterface = true
                    };
                    AddComVisibleTrue(itf.CustomAttributes);
                    // make base type inherit from this interface
                    codeType.BaseTypes.Add(new CodeTypeReference(itf.Name));
                    // clone interface members
                    foreach (CodeTypeMember m in codeType.Members)
                    {
                        var itfM = CloneMember(m);
                        itfM.CustomAttributes.Clear();
                        itf.Members.Add(itfM);
                    }
                    codeTypeDeclarations.Add(itf);
                }
                codeNamespace.Types.AddRange(codeTypeDeclarations.ToArray());
            }
            private static CodeTypeMember CloneMember(CodeTypeMember m)
            {
                var ms = new MemoryStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, m);
                ms.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(ms) as CodeTypeMember;
            }
            private static void AddComVisibleTrue(CodeAttributeDeclarationCollection attrs)
            {
                attrs.Add(new CodeAttributeDeclaration(
                    new CodeTypeReference("System.Runtime.InteropServices.ComVisibleAttribute"),
                    new[] { new CodeAttributeArgument(new CodePrimitiveExpression(true)) }));
            }
            private static void AddClassInterfaceNone(CodeAttributeDeclarationCollection attrs)
            {
                attrs.Add(new CodeAttributeDeclaration(
                    new CodeTypeReference("System.Runtime.InteropServices.ClassInterface"),
                    new[] { new CodeAttributeArgument(new CodeFieldReferenceExpression(
                    new CodeTypeReferenceExpression("System.Runtime.InteropServices.ClassInterfaceType"), 
                    ClassInterfaceType.None.ToString()))
                        }));
            }
        }
    }
