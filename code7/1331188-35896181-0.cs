     private void InitializePdfView<TView, TViewModel>(ParticipantBasic selectedParticipant, string regionName, string viewName)
    {
        IRegion region = this.regionManager.Regions[regionName];
        if (region == null) return;
        // Check to see if we need to create an instance of the view.
        var view = region.GetView(viewName) as TView;
        if (view == null)
        {
            // Create a new instance of the EmployeeDetailsView using the Unity container.
            view = this.container.Resolve<TView>();
            // Add the view to the main region. This automatically activates the view too.
            region.Add(view, viewName);
        }
        else
        {
            // The view has already been added to the region so just activate it.
            region.Activate(view);
        }
        // Set the current employee property on the view model.
        var viewModel = view.DataContext as TViewModel;
        if (viewModel != null)
        {
            viewModel.CurrentParticipant = selectedParticipant;
        }
    }
