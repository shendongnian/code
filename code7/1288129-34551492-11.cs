    protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                viewType => this.mvvmTypeLocator.GetViewModelTypeFromViewType(viewType));
        }
