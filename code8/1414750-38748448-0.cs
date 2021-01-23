        public partial class SelfClosingForm : Form
        {
            public SelfClosingForm()
            {
                InitializeComponent();
            }
    
            private void SelfClosingForm_Load(object sender, EventArgs e)
            {
                Close();
            }
        }
        protected override void OnCreateMainForm()
        {
            ...
        
            if (error)
            {
                //this is need to avoid the app hard crashing with NoStartupFormException
                this.MainForm = new SelfClosingForm();
                return;
            }               
            ...
