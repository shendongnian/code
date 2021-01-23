    public interface IProducer
    {
       List<string> GetResponses();
    }
    [Export(typeof(IProducer))] // Other attributes needed for MEF Export to differentiate the multiple IProducer implementations
    public LocalProducer : IProducer
    {
       public List<string> GetResponse()
       {
           // get files from a directory
       }
    }
    [Export(typeof(IProducer))]
    public EmailProducer : IProducer
    {
       public List<string> GetResponse()
       {
           // get files from email account
       }
    }
    public class ConsumerActor
    {
        public class Consume
        {
           public Consume(string file) { this.File = file; }
           
           public string File { get; set; }
        }
        public ConsumerActor() 
        {
           _retriever = Context.ActorOf(Props.Create<ResponseRetrieverActor>(), "retriever");
           var interval = 10000;
           Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(0, interval, _retriever, new ResponseRetrieverActor.RetrieveResponses(), Self);
           Start(); 
        }
        private void Start()
        {
            Receive<Consume>(msg => 
            {
               // do something with the msg.File 
            });
        }
        
        private IActorRef _retriever;
    }
    public class ResponseRetrieverActor
    {
      public class RetrieveResponses { }
      public ConsumerActor() { Start(); }
      private void Start()
      {
        Receive<RetrieveResponses>(msg => HandleRetrieveResponses());  
      }
      
      private void HandleRetrieveResponses()
      {
         var transportType = TransportFactory.GetTransportType(); // Gets transport protocol for the producer we need to use (Email, File, ect.)
         var producer = ServiceLocator.Current.GetInstance<IProducer>(transportType); // Gets a producer from the IoC container for the specified transportType
        
         var responses = producer.GetResponses();
         foreach(var response in responseFiles)
         {
             Context.Parent.Tell(new ConsumerActor.Consume(response));
         }
      }
    }
