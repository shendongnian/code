    public delegate void UControlButtonCloseClickedHandler(UControl sender, EventArgs e);
    public partial class UControl : UserControl
    {
        public event UControlButtonCloseClickedHandler UControlButtonCloseClicked;
        public UControl()
        {
            InitializeComponent();
            btnAdd.Click += ButtonAdd_Click;
            btnSelect.Click += ButtonSelect_Click;
            btnClose.Click += ButtonClose_Click;
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            UControlButtonCloseClicked(this, new EventArgs());
        }
    }
