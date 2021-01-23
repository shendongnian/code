    protected RelayCommand NavigateToViewCommand() 
    {
        return new RelayCommand((viewName) => {
            Debug.WriteLine("It fired.");
            Navigation.Navigate(ServiceLocator.Current
                      .GetInstance<IViewLocator>()
                      .GetViewForNavigation(viewName.ToString()));
        });
    }
