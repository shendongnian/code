    private void ChangeViewModel(IPageViewModel viewModel)
    {
        // If the view model is not in the collection, it is added.
        if (!PageViewModels.Contains(viewModel))
            PageViewModels.Add(viewModel);
        // So we can just assign the view mdoel here, since we know for sure
        // it is in the collection.
        CurrentPageViewModel = viewModel;
    }
