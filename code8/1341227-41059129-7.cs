    public class MyModel 
    {
        private readonly IMyRepository repo;
        public MyModel(IMyRepository repo) 
        {
            this.repo = repo;
        }
        ... do whatever you want with your repo
        public string AProperty { get; set; }
        ... other properties here
    }
 
