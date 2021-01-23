    public delegate void UControlButtonClickedHandler(UControl sender, EventArgs e);
    public partial class UControl : UserControl
    {
        public event UControlButtonClickedHandler UControlButtonClicked;
        public UControl()
        {
            InitializeComponent();
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            UControlButtonClicked(this, new EventArgs());
        }
    }
