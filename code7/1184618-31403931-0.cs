     public partial class Form1 : Form
        {
            NumberToEnglish Obj = new NumberToEnglish();
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox2.Text = Obj.changeCurrencyToWords(textBox1.Text);//As your method accept a string..
            }
        }
