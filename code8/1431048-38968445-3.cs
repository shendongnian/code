    public static class ReaderExtensions
    {
         public string GetString(this OleDbDataReader reader, string colName)
         {
             string result = "";
             if(!string.IsNullOrEmpty(colName))
             {
                 int pos = reader.GetOrdinal(colName);
                 result = reader.GetString(pos);
             }
             return result;
         }
         ... other extensions for Int, Decimals, DateTime etc...
    }
