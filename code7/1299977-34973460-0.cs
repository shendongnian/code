    public class SequentialSqlServerGuidConverter : SqlServerGuidConverter 
    {
        public override object ToDbValue(Type fieldType, object value)
        {  
            if (value is Guid && value.Equals(Guid.Empty))
            {
                var newGuid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd);
                return newGuid;
            }
            return base.ToDbValue(fieldType, value);
        }
    }
