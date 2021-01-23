    public class MyEntity
    {
        private readonly IMyEntityStatusService myEntityStatusService;
    
        public MyEntity(IMyEntityStatusService myEntityStatusService)
        {
            this.myEntityStatusService = myEntityStatusService;
        }
    
        public MyEntityStatus Status { set; get; }
    
        public void MethodInWhichStatusMayChange()
        {
            //now you use the private myEntityStatusService field
        }
    }
