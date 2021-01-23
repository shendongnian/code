    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Resources;
    namespace DynamicEmbed
    {
        class Program
        {
            static void Main(string[] args)
            {
                var parameters = new CompilerParameters
                {
                    GenerateExecutable = true,
                    OutputAssembly = Path.Combine(Environment.CurrentDirectory, Path.GetTempFileName()) + ".exe",
                };
                // Based on the code your template uses, these will need to change
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.Core.dll");
                parameters.ReferencedAssemblies.Add("System.Linq.dll");
                // Create the embedded resource file on disk
                string embeddedResourceFile = Path.GetTempFileName();
                using (var rw = new ResourceWriter(embeddedResourceFile))
                {
                    var tempFile = Path.GetTempFileName();
                    File.WriteAllText(tempFile, "Hello, World!");
                    rw.AddResourceData("my.resource.key", "ResourceTypeCode.ByteArray", File.ReadAllBytes(tempFile));
                }
                // Embed the resource file into the exe
                parameters.EmbeddedResources.Add(embeddedResourceFile);
                // Source code for dynamically generated exe
                string source =
    @"
    using System;
    using System.Linq;
    using System.Resources;
    namespace DynamicallyEmbeded
    {
        class Program
        {
            static void Main(string[] args)
            {
                var resourceName = typeof(Program).Assembly.GetManifestResourceNames()[0];
                Console.WriteLine(""Embedded resource name: {0}"", resourceName);
                var stream = typeof(Program).Assembly.GetManifestResourceStream(resourceName);
                var resourceData = new byte[] { };
                using (var rr = new ResourceReader(stream))
                {
                    var resourceType = """";
                    rr.GetResourceData(""my.resource.key"", out resourceType, out resourceData);
                }
                var contents = new string(resourceData.Select(x => (char)x).ToArray());
                Console.WriteLine(""Embedded resource contents: {0}"", contents);
                Console.Write(""Press any key to continue . . ."");
                Console.ReadKey();
            }
        }
    }";
                // Create the code
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                var results = provider.CompileAssemblyFromSource(parameters, source);
                // Start the program (just to show it worked)
                if (results.Errors.Count == 0)
                {
                    Process.Start(parameters.OutputAssembly);
                }
            }
        }
    }
