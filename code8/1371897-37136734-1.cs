    private void dataGridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var SelectedItem = dataGridCustomers.SelectedItem;
        string UserControlName = ((UseCase)SelectedItem).UsecaseName;
        Assembly ass = Assembly.GetExecutingAssembly();
        foreach (var item in ass.GetTypes())
        {
            if (item.Name == UserControlName)
            {
                UserControl uc = (UserControl)Activator.CreateInstance(item,null);
                HostGrid.Children.Add(uc);
            }
        }
    }
