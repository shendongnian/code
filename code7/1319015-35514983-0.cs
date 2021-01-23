    public partial class form1 : Form
    {
        public form1()
        {
        InitializeComponent();
        }
        //Paste this in your form:
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //... your code here
    }
