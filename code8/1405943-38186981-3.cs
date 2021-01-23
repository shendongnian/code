    using System;
    using Windows.Storage;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    ...
    private async void buttonSave_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var storageFolder = ApplicationData.Current.LocalFolder;
        var sampleFile = await storageFolder.CreateFileAsync("sample.txt",
          CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(sampleFile, textBox.Text);
      }
      catch (Exception ex)
      {
        var msgbox = new MessageDialog(ex.ToString(), "Error");
        await msgbox.ShowAsync();
      }
    }
    
    private async void buttonLoad_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var storageFolder = ApplicationData.Current.LocalFolder;
        var sampleFile = await storageFolder.GetFileAsync("sample.txt");
        textBox.Text = await FileIO.ReadTextAsync(sampleFile);
      }
      catch (Exception ex)
      {
        var msgbox = new MessageDialog(ex.ToString(), "Error");
        await msgbox.ShowAsync();
      }
    }
