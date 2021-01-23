    public override void OnAppearing()
    {
        var viewModel = new SalesViewModel();
        this.BindingContext = viewModel;
    }
