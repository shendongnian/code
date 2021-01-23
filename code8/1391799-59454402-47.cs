        public MainWindowVM(IServiceFactory<BaseVM> viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }
        private void OnCategorySelectedEvent(Category category)
        {
            CurrentView = viewModelFactory.Create<SubCategorySelectionVM>(category);
        }
        private void OnHomeEvent()
        {
            CurrentView = viewModelFactory.Get<CategorySelectionVM>();
        }
