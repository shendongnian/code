    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://ddragon.leagueoflegends.com/api/versions.json");
                var json = await response.Content.ReadAsStringAsync();
                comboBox1.DataSource = JsonConvert.DeserializeObject<IEnumerable<string>>(json);
            }
        }
    }
