    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public class BaseForm : Form
    {
        public override Color BackColor
        {
            get
            {
                return Color.Cyan;
            }
            set
            {
                base.BackColor = value;
            }
        }
    }
