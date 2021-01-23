    public partial class Form2 : Form
    {                           
        private Form1 _form1;
        
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            _form1.AddControl(/*Some Control*/); 
        }
    }
