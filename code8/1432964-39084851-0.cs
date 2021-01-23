     private CodeTypeMember[] GetGeneratedFieldCollection(JSchema schema)
        {
             var codeMemberFieldList = new List<CodeMemberField>();
            foreach (var property in schema.Properties)
            {
                if(property.Value.Type.ToString() != "Array, Null")
                {
                    codeMemberFieldList.Add(new CodeMemberField
                    {
                        Type = new CodeTypeReference(JSchemaTypeHelper.GetJSchemaSystemType(property.Value.Type)),
                        Name = property.Key,
                        Attributes = MemberAttributes.Public
                    });
                }
                else
                {
                    var subTypeAssembly = CreateSubType("SubRunTimeType", property.Value.Items.FirstOrDefault());
                    var type = subTypeAssembly.DefinedTypes.Skip(1).FirstOrDefault();
                    Type listType = typeof(List<>).MakeGenericType(type);
                    var codeMemberField = new CodeMemberField
                    {
                        Type = new CodeTypeReference(listType),
                        Name = property.Key,
                        Attributes = MemberAttributes.Public
                    };
                    codeMemberFieldList.Add(codeMemberField);
                }
            }
            return codeMemberFieldList.ToArray();
        }
