    public class Message
    {
        public string message { get; set; }
        public string code { get; set; }
        
    }
    public class MessageInitializer
    {
        DataSet ds;
        DataRow dr;
        Message[] ms;
        MessageInitializer()
        {
            this.ms = new Message[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                ms[i] = new Message
                {
                    code = (string)dr.ItemArray[0],
                    message = (string)dr.ItemArray[1]
                };
            }
        }
    }
