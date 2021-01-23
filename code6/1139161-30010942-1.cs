    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public class BaseForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.BackColor = Color.Cyan;
            base.OnActivated(e);
        }
    }
