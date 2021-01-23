    public class MessageInitializer
    {
        DataSet ds;
        DataRow dr;
        Dictionary<string, Message> ms;
        MessageInitializer()
        {
            this.ms = new Dictionary<string, Message>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                ms.Add(dr.ItemArray[0].ToString(), new Message
                {
                     Code = dr.ItemArray[0].ToString(),
                     Message = dr.ItemArray[1].ToString(),
                });
            }
        }
    }
