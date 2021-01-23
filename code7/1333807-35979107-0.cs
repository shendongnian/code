    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            bool quantityParse = int.TryParse(textBox1.Text, out quantity);
            string productName = "Product Name"; // Sample Name
            double productPrice = 300; // Sample Price
            if (quantityParse)
            {
                ListViewItem lvi = new ListViewItem(productName); // Name
                lvi.SubItems.Add(quantity.ToString()); // Quantity
                lvi.SubItems.Add(productPrice.ToString()); // Price
                lvi.SubItems.Add((productPrice * quantity).ToString()); // Subtotal
                listView1.Items.Add(lvi);
            }
        }
    }
