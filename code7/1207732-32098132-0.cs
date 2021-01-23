    public partial class TheForm : Form
    {
        private Font _font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular);
        private bool _hovering = false;
        public TheForm() {
            InitializeComponent();
            picBox.Paint += new PaintEventHandler(picBox_Paint);
            picBox.MouseEnter += (sender, e) => UpdateText(true);
            picBox.MouseLeave += (sender, e) => UpdateText(false);
        }
        private void picBox_Paint(object sender, PaintEventArgs e) {
            if (_hovering)
                e.Graphics.DrawString("Yo Dawg!", _font, Brushes.Black, 100, 100);
        }
        private void UpdateText(bool show) {
            _hovering = show;
            picBox.Invalidate();
        }
    }
