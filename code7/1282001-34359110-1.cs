    public class MainForm : Form
    {
        private SubForm _subForm1 = new SubForm();
        private SubForm _subForm2 = new SubForm();
        public MainForm()
        {
            InitializeComponents();
            // more initializatino
            _subForm1.ButtonClicked += subForm1_ButtonClicked;
            _subForm2.ButtonClicked += subForm2_ButtonClicked;
        }
        private void subForm1_ButtonClicked(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void subForm2_ButtonClicked(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
