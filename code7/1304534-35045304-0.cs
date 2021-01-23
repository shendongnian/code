    public class SecondWindow : Window
    {
        private readonly FirstWindow _owner;
        public SecondWindow(FirstWindow owner)
        {
            _owner = owner;
        }
        private void OnSwardButtonClick(object sender, EventArgs e)
        {
            _owner.TextBlockValue = "New value";
        }
    }
