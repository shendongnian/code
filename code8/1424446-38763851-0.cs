Change the MaxWidth property of the TextBox as you resize the window would solve your problem. Although, I don't think it's a clean way to do that.
        int margin = 40; // Set your margin
        public MainPage()
        {
            this.InitializeComponent();
            InputTextBox.MaxWidth = Window.Current.Bounds.Width - margin;
            Window.Current.SizeChanged += Current_SizeChanged;
        }
        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            var size = e.Size;
            InputTextBox.MaxWidth = size.Width - margin;
        }
