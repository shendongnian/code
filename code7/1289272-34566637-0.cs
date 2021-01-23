    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }
        public event EventHandler ButtonClicked;
        public virtual void OnButtonClicked(EventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OnButtonClicked(EventArgs.Empty);
        }
    }
