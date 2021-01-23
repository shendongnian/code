    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Test> DataSource;
 
        public void PopulateDGV1()
        {
            DataSource=new List<Test>() { new Test() { Age = 2, Name = "Test" } };
            //TODO:read your XML file
            DGV1.DataSource = DataSource;
        }
        private void LoadDGV1_Click(object sender, EventArgs e)
        {
            PopulateDGV1();
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
