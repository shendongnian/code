    public partial class CustomControl : UserControl, ISupportInitialize {
        public CustomControl() {
            InitializeComponent();
        }
        private bool initializing;
        private string id = "";
        public string ID {
            get { return id; }
            set { id = value;
                  if (!initializing) label1.Text = value;
            }
        }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text {
            get { return base.Text; }
            set {
                base.Text = value;
                if (!initializing && !this.DesignMode) label1.Text = value;
            }
        }
        public void BeginInit() {
            initializing = true;
        }
        public void EndInit() {
            initializing = false;
            label1.Text = ID;
        }
    }
