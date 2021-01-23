    async void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var _Name = "HelloWorld.txt";
        var _Folder = KnownFolders.DocumentsLibrary;
        var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
        // create file 
        var _File = await _Folder.CreateFileAsync(_Name, _Option);
        // write content
        var _WriteThis = "Hello world!";
        await Windows.Storage.FileIO.WriteTextAsync(_File, _WriteThis);
        // acquire file
        try { _File = await _Folder.GetFileAsync(_Name); }
        catch (FileNotFoundException) { /* TODO */ }
        // read content
        var _Content = await FileIO.ReadTextAsync(_File);
        await new Windows.UI.Popups.MessageDialog(_Content).ShowAsync();
    }
