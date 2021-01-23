    public partial class Form2 : Form
    {
        public Form2(Form1 Parent)
        {
            InitializeComponent();
            Parent.ShowMessage("Hello from Form2!");
        }
    }
