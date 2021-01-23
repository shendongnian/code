     public class ClientClass :ClientBase<IYourService>,IYourService
        {
            public string SampleGet()
            {
               return base.Channel.SampleGet();
            }
        }
