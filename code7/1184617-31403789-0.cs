     public partial class Form1 : Form
        {
            NumberToEnglish neObj = new NumberToEnglish();
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox2.Text = neObj.changeCurrencyToWords(Convert.ToDouble(textBox1.Text));
            }
        }
