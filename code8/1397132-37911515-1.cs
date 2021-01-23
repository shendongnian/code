    public partial class mainFrm : Form
    {
        private HashSet<string> uniqueTexts = new HashSet<string>();
        public mainFrm()
        {
            InitializeComponent();
        }
        .....
        private void clipboardUpdater_Tick(object sender, EventArgs e)
        {
            string clipText = Clipboard.GetText();
            if (!uniqueTexts.Any(x => x.Equals(clipText, StringComparison.OrdinalIgnoreCase)))
            {
                clipboardSaveTextBox.AppendText("\n" + clipText);
                uniqueTexts.Add(clipText);
            }
        }
