            var columnName = SoftDeleteAttribute.GetSoftDeleteColumnName((expression.Target.ElementType));
            
            if (columnName == null  || !expression.Target.ElementType.Members.Any(m => m.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase)))
            {
                return base.Visit(expression);
            }
            var binding = expression.Bind();
            return binding.Filter(binding.VariableType.Variable(binding.VariableName).Property(columnName).NotEqual(DbExpression.FromBoolean(true)));
