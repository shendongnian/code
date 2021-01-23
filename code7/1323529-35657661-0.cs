       // Returns a new BigInt parameter
       public SqlParameter ParamBigInt(string paramName, long v)
       {
           // Fixup parameter name
           string name = paramName.Trim();
           if (!name.StartsWith("@"))
               name = "@" + name;
           // Make the new parameter
           return new SqlParameter(name, SqlDbType.BigInt)
           {
               Value = p;
           };
       }
