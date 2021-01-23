    internal class SomeOtherClass
    {
        public SomeOtherClass( IMySharedService sharedService )
        {
            _sharedService = sharedService;
        }
        
        public void ProcessData()
        {
            var item = _sharedService.GetData();
            if (item == null)
                return;
            // Do something with the item...
        }
        private readonly IMySharedService _sharedService;
    }
