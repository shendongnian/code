    public partial class Form2 : Form
    {
        Form1 Form1Copy;
        public Form2(Form1 Parent)
        {
            InitializeComponent();
            Form1Copy = Parent;
        }
        public void Button_Click(Object sender, EventArgs e)
        {             
            Form1Copy.ShowMessage("Hello from Form2!");
        }
    }
