    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeEvent();
        }
        private void InitializeEvent()
        {
            Event.Calculate += Event_Calculate;
        }
        private int Event_Calculate(object obj1, object obj2)
        {
            int x = 0;
            int y = 0;
            int.TryParse(obj1.ToString(), out x);
            int.TryParse(obj2.ToString(), out y);
            return Event.Add( x, y );
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.label1.Text = Event.OnCalculate(this.textBox1.Text, this.textBox2.Text).ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.label1.Text = Event.OnCalculate(this.textBox1.Text, this.textBox2.Text).ToString();
        }
    }
