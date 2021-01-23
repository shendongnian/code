    public class ServeRich : IGenericInterface<RichPeople>
    {
        private readonly RichPeople _people;
    
        public ServerRich(RichPeople people)
        {
            _people = people;
        }
         
        // C# 6 expression-bodied read-only property
        public RichPeople GenericTypeProperty => _people;
        public void PerformService() { //Serving the rich } 
    }
