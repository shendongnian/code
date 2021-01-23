    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var proxy = new ServiceReference1.ServiceClient();
    
        var photo = await proxy.getEmployeePhotoAsync(12);
        label.Content = photo.Length; 
        proxy.Close();
    }
