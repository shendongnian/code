    private void FillDataGrid()
    {
        var _cDS = new CompanyDataService();
        var Companies = new ObservableCollection<CompanyModel>();
        Companies = _cDS.HandleCompanySelect();
        CompanyICollectionView = CollectionViewSource.GetDefaultView(Companies);
        //CompanyICollectionView.SortDescriptions.Add(new SortDescription("CompanyName", ListSortDirection.Ascending));
        DataContext = this;
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
        {
            cancelButton.Visibility = Visibility.Hidden;
            if (compNameRad.IsChecked == false && 
                compTownRad.IsChecked == false && 
                compPcodeRad.IsChecked == false)
            {
                searchBox.IsEnabled = false;
            }
            dataGrid.SelectedIndex = 0;
            SetDefaultFilter();
         }));
    }
                           
