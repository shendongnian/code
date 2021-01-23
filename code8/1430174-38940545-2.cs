    public class OrdersFixed
        :INotifyRead
    {
        //...
    
        public void BeforeRead(BeforeReadEventArgs e)
        {
            if (e.RecordLine.StartsWith(" ") ||
               e.RecordLine.StartsWith("-"))
                e.SkipThisRecord = true;
        }
    
    }
