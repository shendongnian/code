    partial class Form1 : Form
    {
        private readonly MainForm _mainForm;
        public Form1(MainForm mainForm)
        {
            _mainForm = mainForm;
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mainForm.Show();
        }
    }
