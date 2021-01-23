        Model m = null;
        IViewCallbacks cb;
        public MainViewModel(IViewCallbacks mainViewCallbacks)
        {
             this.cb = mainViewCallbacks;
             m = new Model();
        }
