    class DynamicDisplayHandler
    {
        public void LoadLastServer(Form1 f1)
        {
            Form1 homepage = f1;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DynamicDisplayHandler displayHandler = new DynamicDisplayHandler();
            displayHandler.LoadLastServer(this); //
        }
    }
