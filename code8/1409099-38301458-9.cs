    public partial class Form2 : Form
    {
        Form1 _owner;
        public Form2(Form1 form)
        {
            InitializeComponent();
            _owner = form;
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            _owner.SetText(monthCalendar1.SelectionEnd.ToShortDateString());
        }
