    public partial class Form1 : Form
    {
        public Form1(UserControl control)
        {
            InitializeComponent();
            this.Controls.Add(control);
        }
    }
