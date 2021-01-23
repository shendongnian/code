    private async void RecoveryList_Click(object sender, RoutedEventArgs e)
    {
        StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("List.xml");
        DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<ProductClass>));
    
        using (Stream stream = await file.OpenStreamForReadAsync())
        {
            Products = serializer.ReadObject(stream) as ObservableCollection<ProductClass>;
            ListView1.ItemsSource = Products;
        }
    }
