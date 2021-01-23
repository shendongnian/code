     [System.Web.Script.Services.ScriptMethod]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            List<string> Topics = new List<string>();
            ConnectionClass cl = new ConnectionClass();
            DataTable dt = cl.AutoComplete(prefixText);
                 int i;
           for (i = 0; i < dt.Rows.Count; i++)
               {
                   Topics.Add(dt.Rows[i]["ColumnName"].ToString());//Try to give the column name of the resultset from the datatable
               }
          
          
            return Topics;
    }
