    private void Menu1_Click(object sender, RoutedEventArgs e)
    {
        Point centerPoint = new Point((Container.ActualWidth  / 2) - (500/2), (Container.ActualHeight / 2) - (400 / 2));
        MdiChild newForm = new MdiChild();
        newForm .Title = "My Form";
        //The code omitted for the brevity
        newForm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        Container.Children.Add(newForm);
    }
