    class ViewModel 
    {
        private readonly IDesignerProperties _designerProperties;
        // Inject the proper implementation
        public ViewModel(IDesignerProperties designerProperties)
        {
            _designerProperties = designerProperties;
        }
    }
