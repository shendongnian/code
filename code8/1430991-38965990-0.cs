    public partial class Box : UserControl
    {
        public Box()
        {
            InitializeComponent();
        }
    
        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value; this.Invalidate();
                    if(TextChanged != null)
                        TextChanged(this, EventArgs.Empty)
                }
            }
        }
    
        [Browsable(true)]
        public event EventHandler TextChanged;
    }
