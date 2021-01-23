    private TextBlock textBlock;
    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        // Grab the template controls, e.g.:
        textBlock = GetTemplateChild("MyTextBlock") as TextBlock;
        InitializeDataContext();
        DataContextChanged += (sender, args) => InitializeDataContext();
    }
    private void InitializeDataContext()
    {
        ViewModel ViewModel = DataContext as ViewModel;
        if (viewModel != null)
        {
            // Here we know that both conditions are satisfied
            textBlock.Text = ViewModel.Name;
        }
    }
