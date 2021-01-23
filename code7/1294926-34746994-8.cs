    // this class has to be resolved from the same unity container as SomeClass (see above)
    internal class SomeOtherClass
    {
        public SomeOtherClass( IMySharedService sharedService )
        {
            _sharedService = sharedService;
            _sharedService.DataArrived += OnNewData;
        }
        
        public void ProcessData()
        {
            var item = _sharedService.GetData();
            if (item == null)
                return;
            // Do something with the item...
        }
        private readonly IMySharedService _sharedService;
        private void OnNewData( object item )
        {
            // Do something with the item...
        }
    }
