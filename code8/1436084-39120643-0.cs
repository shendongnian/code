    var bitmap = new Bitmap(Screen.AllScreens[SelectedScreen.Index].Bounds.Width, Screen.AllScreens[SelectedScreen.Index].Bounds.Height);
   
    var graphics = Graphics.FromImage(bitmap);
    graphics.CopyFromScreen(Screen.AllScreens[SelectedScreen.Index].Bounds.Left, Screen.AllScreens[SelectedScreen.Index].Bounds.Top, 0, 0, bitmap.Size);
    this.Dispatcher.Invoke(() => this.PreviewImage.Source = this.ConvertBitmapToBitmapImage(bitmap));
