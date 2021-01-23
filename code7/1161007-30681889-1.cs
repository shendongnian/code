    var page = new Page();
    var dataService = new YourDataService();
    var viewModel = await MainViewModel.InitializeAsync(dataService);
    page.DataContext = viewModel;
    page.Show();
