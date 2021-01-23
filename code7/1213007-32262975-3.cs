    public partial class PopupForm : Form
    {
        public event EventHandler CallRefreshHandler;
        public PopupForm()
        {
            InitializeComponent();
        }
        private void btnRaiseEvent_Click(object sender, EventArgs e)
        {
            EventHandler handler = CallRefreshHandler;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
