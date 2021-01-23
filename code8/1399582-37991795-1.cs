    public class DbColumnTypes {
        public String TABLE_NAME { get; set; };
        public String COLUMN_NAME { get; set; };
        public String DOMAIN_NAME { get; set; };
        public Boolean ISNULLABLE { get; set; };
    }    
    List<DbColumnTypes> dbColumns; //Read that from your DB
    PropertyInfo[] properties = type.GetProperties(BindingFlags.Public).ToArray();
    foreach(PropertyInfo item in properties)
    {
        if(dbColumns.Any(x => x.COLUMN_NAME == item.Name) {
            //compare the Database types to the C# types (varchar with string, etc.)
            if(item.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
            {
                //check if database column is nullable
            }
        }
    }
