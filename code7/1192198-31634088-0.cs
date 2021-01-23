    public class MessageInitializer
    {
        DataSet ds;
        DataRow dr;
        Dictionary<string, string> ms;
        public MessageInitializer()
        {
            this.ms = new Dictionary<string,string>(ds.Tables[0].Rows.Count);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                ms[(string)dr.ItemArray[0]] = (string)dr.ItemArray[1];
            }
        }
    }
