    public partial class UserControl1 : UserControl
    {
        MaskedTextBox maskedTextBox;
        public UserControl1()
        {
            InitializeComponent();
            maskedTextBox = new MaskedTextBox();
        }
        [Editor(typeof(MaskEditor), typeof(UITypeEditor))]
        public string Mask
        {
            get { return maskedTextBox.Mask; }
            set { maskedTextBox.Mask = value; }
        }
    }
