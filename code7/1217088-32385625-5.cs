    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            TestClickTarget.Text = DateTime.Now.ToString("T");
            Box.AppendText("Hello SO users. I'm Javad Amiry." + Environment.NewLine);
            Box.AppendText("Hello SO users. I'm Javad Amiry in second line." + Environment.NewLine);
            Box.AppendText("Hello SO users. I'm Javad Amiry in third line ;)" + Environment.NewLine);
            Box.AppendText("And \"Hello SO users. I'm Javad Amiry.\" the last one :D" + Environment.NewLine);
        }
        private void ShowTextTooltip(object sender, RoutedEventArgs e) {
            var box = e.OriginalSource as TextBox;
            if (box == null || TestClickTarget == null)
                return;
            TestClickTarget.Text = box.SelectedText;
            TooltipPopup.IsOpen = box.SelectionLength != 0;
        }
        private void UpdateTime(object sender, RoutedEventArgs e) {
            TestClickTarget.Text = DateTime.Now.ToString("T");
        }
    }
