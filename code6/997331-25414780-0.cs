    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int XValue{
            set{
                label1.Text = value.ToString(); 
            }
        }
    }
