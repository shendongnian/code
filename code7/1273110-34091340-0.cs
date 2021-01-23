    public partial class BaseForm : Form
        {
            public BaseForm()
            {
                InitializeComponent();
                label1.Text = "asdf";
            }
        }
    ...
    public partial class DerivedForm : BaseForm
        {
            public DerivedForm()
            {
                InitializeComponent();
                label2.Text = "asdfasfd";
            }
        }
