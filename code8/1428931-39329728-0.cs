		public void Process(CodeNamespace code, XmlSchema schema)
		{
			foreach (var type in code.Types.Cast<CodeTypeDeclaration>().Where(x => !x.IsEnum))
			{
				var result = new List<CodeMemberField>();
				var properties = type.Members.OfType<CodeMemberProperty>().ToList();
				foreach (var property in properties)
				{
					ReplacePropertyByField(type, property);
				}
			}
		}
		private static void ReplacePropertyByField(CodeTypeDeclaration type, CodeMemberProperty property)
		{
			var backingField = GetBackingField(property, type);
			backingField.Comments.AddRange(property.Comments);
			backingField.Attributes = property.Attributes;
			backingField.CustomAttributes = property.CustomAttributes;
			backingField.Name = property.Name;
			type.Members.Remove(property);
		}
		private static CodeMemberField GetBackingField(CodeMemberProperty property, CodeTypeDeclaration type)
		{
			var getterExpression = ((CodeMethodReturnStatement)property.GetStatements[0]).Expression;
			var backingFieldName = ((CodeFieldReferenceExpression)getterExpression).FieldName;
			return type.Members.OfType<CodeMemberField>().Single(x => x.Name == backingFieldName);
		}
