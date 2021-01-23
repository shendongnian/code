    public sealed partial class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            this.InitializeComponent();
        }
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            e.Handled = true;
            //your logic
        }
    }
