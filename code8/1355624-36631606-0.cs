    public partial class BaseForm : Form
        {
            public BaseForm()
            {
                InitializeComponent();
            }
    
            [Browsable(true)]
            [Category("Base Form")]
            [Description("Define the window title.")]
            public String WindowTitle
            {
                get { return label1.Text; }
                set { label1.Text = value; }
            }
        }
