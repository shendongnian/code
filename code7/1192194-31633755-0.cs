    public class Message
    {
        string Message;
        string Code;
    }
    public class MessageInitializer
    {
        DataSet ds;
        DataRow dr;
        List<Message> ms;
        MessageInitializer()
        {
            this.ms = new List<Message>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                ms.Add(new Message
                {
                     Code = dr.ItemArray[0].ToString(),
                     Message = dr.ItemArray[1].ToString(),
                });
            }
        }
    }
