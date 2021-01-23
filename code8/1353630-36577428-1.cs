    public class ClientService : Service
    {
        public Init Init { get; set; }
        public ILayout ActiveForm { get; set; }
    
        public HttpResult Post(Person request)
        {
            //Use this.Init or this.ActiveForm
        }
    }
