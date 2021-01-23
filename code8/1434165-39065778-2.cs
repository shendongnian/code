    public class BaseClass<T> 
        where T : new ()
    {
        protected List<T> list;
        protected string query;
        protected PropertyInfo[] fProperties;
        protected Assembly fStoreAssembly;
        public BaseClass()
        {
            list = new List<T>();
            fStoreAssembly = Assembly.GetAssembly (typeof(T));
		    fProperties = typeof(T).GetProperties();
        }
        public void Read()
        {
            SQLiteConnection conn = null;
            SQLiteCommand command = null;
            SQLiteDataReader reader = null;
            
            try
            {
                conn = new SQLiteConnection(db.db);
                conn.Open();
                command = new SQLiteCommand(query, conn);
                reader = command.ExecuteReader();
                StoreResults (reader);
                            
                conn.Close();
            }
            catch (Exception ex) 
            {
                //deal with the exception here
            }
        }
        //Store results walks through all the records returned and 
        //creates new instances of the store object and saves in the list,
        //using reflection
		protected void StoreResults (SQLiteDataReader reader)
		{
			if (fProperties == null)
				throw new Exception ("Store type definition is missing");
			while (reader.Read ())
			{                
				object newStoreItem = fStoreAssembly.CreateInstance (typeof(T).FullName);                
				foreach (PropertyInfo pi in fProperties)
				{
					string lcName = pi.Name.ToLower ();
                    
                    if (HasColumn(reader, lcName))
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal(lcName)))
                            pi.SetValue(newStoreItem, reader[lcName], null);                    
                    }
				}
				list.Add (newStoreItem);
			}
		}
		public bool HasColumn (SQLiteDataReader reader, string columnName)
		{
			foreach (DataRow row in reader.GetSchemaTable().Rows)
			{
				if (row ["ColumnName"].ToString () == columnName)
					return true;
			}
			return false;
		}
    }
