    private readonly Balloon _balloonTip = new Balloon();
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = HandledNumerics(sender, e);
        }
        private bool HandledNumerics(object sender, KeyPressEventArgs e)
        {
            var handled = !(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete));
            if (handled)
            {
                ShowBalloon("Warning", "Invalid Input!\nOnly numeric value is acceptable", (TextBox)sender);
            }
            return handled;
        }
        private void ShowBalloon(string title, string text, Control parent, TooltipIcon icon = TooltipIcon.Warning)
        {
            _balloonTip.Title = title;
            _balloonTip.Text = text;
            _balloonTip.Parent = parent;
            _balloonTip.TitleIcon = icon;
            _balloonTip.Show();
        }
