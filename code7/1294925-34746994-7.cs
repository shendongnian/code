    // this class has to be resolved from the unity container, perhaps via AutoWireViewModel
    internal class SomeClass
    {
        public SomeClass( IMySharedService sharedService )
        {
            _sharedService = sharedService;
        }
        
        public void PerformImport( IEnumerable data )
        {
            foreach (var item in data)
                _sharedService.AddData( item );
        }
        private readonly IMySharedService _sharedService;
    }
