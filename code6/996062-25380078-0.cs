    public partial class Form1 : Form
    {
        Form1Data _data;
        public Form1()
        {
            InitializeComponent();
        }
        public SetData(Form1Data data)
        {
            _data = data;
        }
    }
    struct MyData
    {
        public string Name;
        public string Address;
    }
