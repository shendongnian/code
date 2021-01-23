    public partial class CustomUserControl : UserControl {
        public CustomUserControl() {
            InitializeComponent();
            EnableBinding = true; // !!!
        }
        [DefaultValue(true), Category("Behavior")]
        public bool EnableBinding { get; set; }
        [DefaultValue(false), Category("Behavior")]
        public bool NeedApprove { get; set; }
    }
