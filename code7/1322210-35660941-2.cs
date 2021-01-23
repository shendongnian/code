    public class MyViewModel
    {
        [FromServices]
        public IMyService myService { get; set; }
        public ClaimantSearchViewModel(IMyService myService)
        {
            this.myService = myService;
        }
    }
