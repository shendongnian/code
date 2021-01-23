    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = MySingletonClass.Instance.MySharedProperty;
        }
    }
