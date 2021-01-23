    public sealed partial class MyDialog2 : ContentDialog
    {
        ...
    }
    public sealed partial class MyDialog1 : ContentDialog
    {
        ...
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            // Hide MyDialog1
            this.Hide(); 
            // Show MyDialog2 from MyDialog1
            var C = new MyDialog2();
            await C.ShowAsync();
            // Unhide MyDialog1
            var T = ShowAsync();
        }
    }
