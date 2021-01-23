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
            if (!uniqueTexts.Any(x => string.Compare(clipText, x, true) == 0))
            {
                clipboardSaveTextBox.AppendText("\n" + clipText);
                uniqueTexts.Add(clipText);
            }
        }
