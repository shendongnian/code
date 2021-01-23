    public partial class FormScheduler : Form
    {
        public FormScheduler()
        {
            InitializeComponent();
        }
        public string StartDate
        {
            get { return mPeriodSettings.StartDate; }
            set { mPeriodSettings.StartDate = value; }
        }
        private void settingsSchPer_Click(object sender, EventArgs e)
        {
            FormSchemaPeriodSettings formSchPer = new FormSchemaPeriodSettings();
            if (formSchPer.ShowDialog() == DialogResult.OK)
                StartDate = formSchPer.ResultDate;
        }
    }
    
    public partial class FormSchemaPeriodSettings : Form
    {
        public FormSchemaPeriodSettings()
        {
            InitializeComponent();
        }
        public string ResultDate;
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ResultDate = startDate.ValueToShortDateString();
            Close();
        }
    }
