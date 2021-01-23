    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var data = new List<Data>();
            data.Add(new Data { A = "CAN", B = "YOU", C = "HELP", D = "ME" });
            data.Add(new Data { A = "CAN", B = "YOU", C = "HELP", D = "ME" });
            data.Add(new Data { A = "CAN", B = "YOU", C = "HELP", D = "ME" });
            data.Add(new Data { A = "CAN", B = "YOU", C = "HELP", D = "ME" });
            dataGridView1.DataSource = data;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var selectedCells = dataGridView1.SelectedCells;
            var array = new DataGridViewCell[selectedCells.Count];
            selectedCells.CopyTo(array,0);
            var sorted = array.OrderBy(c => c.ColumnIndex);
            var s = string.Join(Environment.NewLine, sorted.Select(c => c.Value));
            textBox1.Text = s;
        }
    }
    public class Data
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
    }
