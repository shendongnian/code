    namespace Project3
    {
        public partial class Form1 : Form
        {
            private Calculator calc;
            public Form1()
            {
                InitializeComponent();
                calc = new Calculator();
                label1.Text = "";
            }
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                label1.Text = btn.Text;
                int num1 = Int32.Parse(textBox1.Text);
                int num2 = Int32.Parse(textBox2.Text);
                // subscribes a handler to your event
                calc.CalculateNow += (n1, n2) => { return n1 + n2; }
                // method that invokes your event on Calculator class
                int finalr = calc.InvokeCalc(num1, num2);
                if (finalr != null)
                {
                    label1.Text = "" + finalr;
                }
                else
                {
                    label1.Text = "Error!";
                }
            }
        }
    }
