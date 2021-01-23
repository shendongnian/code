    private void PicInputBtn_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            DefaultExt = ".jpg",
            Filter = "img file|*.jpg" // And you had a ',' over here.
        };
        if ((Nullable<bool>dialog.ShowDialog()) == true) // You forgot Nullable<bool>
        {
            // string filename = dlg.FileName;
        }
        else
        {
            return;
        }
    ｝
