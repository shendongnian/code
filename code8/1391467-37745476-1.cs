    namespace ContentDialogDemo01
    {
    // Define your own ContentDialogResult enum
    public enum MyResult
    {
        Yes,
        No,
        Cancle,
        Nothing
    }
    public sealed partial class MyCustomContentDialog : ContentDialog
    {
        public MyResult Result { get; set; }
        public MyCustomContentDialog()
        {
            this.InitializeComponent();
            this.Result = MyResult.Nothing;
        }
        // Handle the button clicks from dialog
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Yes;
            // Close the dialog
            dialog.Hide();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.No;
            // Close the dialog
            dialog.Hide();
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Cancle;
            // Close the dialog
            dialog.Hide();
        }
    }
    }
