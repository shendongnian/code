    public ViewRenderer(
            ICompositeViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IActionContextAccessor actionAccessor
            )
        {
            this.viewEngine = viewEngine;
            this.tempDataProvider = tempDataProvider;
            this.actionAccessor = actionAccessor;
            
        }
        private ICompositeViewEngine viewEngine;
        private ITempDataProvider tempDataProvider;
        private IActionContextAccessor actionAccessor;
