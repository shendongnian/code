    private void Button_Click(object sender, RoutedEventArgs e)
    {
        UserDatas["Points"] = UserDatas["Points"] + 5;
        UserDatas["Levels"] = UserDatas["Levels"] + 1;
        NavigationService.Navigate(new Uri("/Views/P2.xaml", UriKind.Relative));
    }
