    public delegate int CalculateEventHandler(object obj1, object obj2);
    public partial class Form1 : Form
    {
        public event CalculateEventHandler Calculate;
        private string OnCalculate(string text1, string text2)
        {
            string result = "0";
            if (this.Calculate != null)
            {
                result = this.Calculate(this.textBox1.Text, this.textBox2.Text).ToString();
            }
            return result;
        }
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeEvent();
        }
        private void InitializeEvent()
        {
            this.Calculate += Form1_Calculate;
        }
        private int Form1_Calculate(object obj1, object obj2)
        {
            int a = 0;
            int b = 0;
            int.TryParse(obj1.ToString(), out a);
            int.TryParse(obj2.ToString(), out b);
            return a + b;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.label1.Text = OnCalculate(this.textBox1.Text, this.textBox2.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.label1.Text = OnCalculate(this.textBox1.Text, this.textBox2.Text);
        }
    }
