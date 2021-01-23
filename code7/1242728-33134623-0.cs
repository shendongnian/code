    public class MyHandler : ContentHandler
    {
        public MyHandler ()
        {
            OnPublishing<abcPart>((context, part) => {
                /*your logic here*/
            });
        }
    }
    
