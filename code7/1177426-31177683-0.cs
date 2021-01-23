     public String getName()
     {
         if (rows.Rows != null && rows.Rows.Count > 0)
            {
                DataRow row = rows.Rows[0];
                return row["company_name"].ToString();
            }
            return string.Empty;
     }
