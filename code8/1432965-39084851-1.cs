        public Assembly CreateType(JSchema schema)
        {
            CodeTypeDeclaration CodeType = new CodeTypeDeclaration();
            CodeType.Name = schema.Id.ToString();
            CodeType.IsClass = true;
            CodeType.Attributes = MemberAttributes.Public;
            CodeNamespace.Types.Add(CodeType);
            CodeType = GetFields(CodeType, schema);
            CodeCompileUnit CodeUnit = new CodeCompileUnit();
            CodeUnit.ReferencedAssemblies.AddRange(GetReferenceList());
            CodeUnit.Namespaces.Add(CodeNamespace);
            return CreateTypeInMemory(CodeUnit);
        }
        private Assembly CreateTypeInMemory(CodeCompileUnit codeUnit)
        {
            Assembly CompiledAssembly = null;
            CompilerParameters CompilerParams = new CompilerParameters();
            CompilerParams.ReferencedAssemblies.AddRange(new[] { "System.dll" });
            CompilerParams.GenerateInMemory = true;
            CompilerParams.GenerateExecutable = false;
            CSharpCodeProvider Compiler = new CSharpCodeProvider();
            CompilerResults Results = Compiler.CompileAssemblyFromDom(CompilerParams, codeUnit);
            if (Results.Errors != null && Results.Errors.Count == 0)
            {
                CompiledAssembly = Results.CompiledAssembly;
            }
            return CompiledAssembly;
        }
        private CodeTypeDeclaration GetFields(CodeTypeDeclaration CodeType, JSchema schema)
        {
            CodeType.Members.AddRange(GetGeneratedFieldCollection(schema));
            return CodeType;
        }
        private CodeTypeMember[] GetGeneratedFieldCollection(JSchema schema)
        {
            var codeMemberFieldList = new List<CodeMemberField>();
            foreach (var property in schema.Properties)
            {
                if (property.Value.Type.ToString() != "Array, Null" && property.Value.Type.ToString() != "Object, Null")
                {
                    codeMemberFieldList.Add(new CodeMemberField
                    {
                        Type = new CodeTypeReference(JSchemaTypeHelper.GetJSchemaSystemType(property.Value.Type)),
                        Name = property.Key,
                        Attributes = MemberAttributes.Public
                    });
                }
                else if(property.Value.Type.ToString() == "Array, Null")
                {
                    var generatedAssembly = CreateType(property.Value.Items.FirstOrDefault());
                    var type = GetTypeFromAssembly(generatedAssembly, property);
                    Type listType = typeof(List<>).MakeGenericType(type);
                    var codeMemberField = new CodeMemberField
                    {
                        Type = new CodeTypeReference(listType),
                        Name = property.Key,
                        Attributes = MemberAttributes.Public
                    };
                    codeMemberFieldList.Add(codeMemberField);
                }
                else
                {
                    var generatedAssembly = CreateType(property.Value.Items.FirstOrDefault());
                    var type = GetTypeFromAssembly(generatedAssembly, property);
                    var codeMemberField = new CodeMemberField
                    {
                        Type = new CodeTypeReference(type),
                        Name = property.Key,
                        Attributes = MemberAttributes.Public
                    };
                    codeMemberFieldList.Add(codeMemberField);
                }
            }
            return codeMemberFieldList.ToArray();
        }
        private string[] GetReferenceList()
        {
            List<string> references = new List<string>();
            references.AddRange(new string[] { "System", "System.Collections", "System.Collections.Generic" });
            return references.ToArray();
        }
        private Type GetTypeFromAssembly(Assembly generatedAssembly, KeyValuePair<string, JSchema> property)
        {
            string definedTypeName = property.Value.Items.FirstOrDefault().Id.ToString();
            return generatedAssembly.DefinedTypes
                .FirstOrDefault(definedtype => definedtype.Name == definedTypeName);
        }
    
