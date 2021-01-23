    public partial class RESTAURANT : Form
    {
        double soup = 2.49;
        double ordertotal;
        public RESTAURANT()
        {
            InitializeComponent();
        }
        private void RESTAURANT_Load(object sender, EventArgs e)
        {
        }
        private void Add_Click(object sender, EventArgs e)
        {
            MenuBox.Items.Add("Soup");
            TotalBox.Items.Add(String.Format("{0:C}", soup));
            ordertotal += soup;
            total.Text = Convert.ToString(String.Format("{0:C}", ordertotal));
        }
        private void TotalBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void PlaceOrder_Click(object sender, EventArgs e)
        {
            new AreYouSure().Show();
            this.Show();
            MenuBox.Items.Clear();
            TotalBox.Items.Clear();
            total.Clear();
            ordertotal = 0;
        }
    }
