    public static bool Insert(List<YourModel> datas, string table)
    {
        bool result = false;
        List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
       
        SqlConnection con = new SqlConnection("your connection string");
        con.Open();
        
        try
        {
            foreach (var data in datas)
            {
                
                values.Clear();
                foreach (var item in data.GetType().GetProperties())
                {          
                     values.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                }
                string xQry = getInsertCommand(table, values);
                SqlCommand cmdi = new SqlCommand(xQry, con);
                cmdi.ExecuteNonQuery();
            }
            result = true;
        }
        catch(Exception ex)
        { throw ex; }
        finally { con.Close(); }
        return result;
    }
