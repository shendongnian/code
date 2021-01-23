    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = GenerateData();
            dataGridView1.Columns[0].ReadOnly = true;
        }
        private List<DataSourceTest> GenerateData()
        {
            return new List<DataSourceTest>()
            {
                new DataSourceTest(1, "A"),
                new DataSourceTest(2, "B"),
                new DataSourceTest(3, "C"),
                new DataSourceTest(4, "D"),
                new DataSourceTest(5, "E"),
                new DataSourceTest(6, "F"),
            };
        }
    }
    public class DataSourceTest
    {
        public DataSourceTest(int id, string name) { ID = id; Name = name; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
