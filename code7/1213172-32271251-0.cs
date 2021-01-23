    private void DisplayToast()
    {
        var toast = CreateToast();
        toast.TextWrapping = TextWrapping.Wrap;
    
        toast.Show();
    }
    
    private static ToastPrompt CreateToast()
    {
        return new ToastPrompt
        {
            Title = "MyToast",
            TextOrientation = System.Windows.Controls.Orientation.Vertical,
            Message = "Toast message",
            ImageSource = new BitmapImage(new Uri("../../ApplicationIcon.png", UriKind.RelativeOrAbsolute))
        };
    }
