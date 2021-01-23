        public void ChangeViewModel(BaseViewModel viewModel)
        {
            //You should implement clone in your base view model
            CurrentPageViewModel = viewModel.Clone();
        }
