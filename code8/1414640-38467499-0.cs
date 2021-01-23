    class MyWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !IsValid(); // your validation code
        }
    }
