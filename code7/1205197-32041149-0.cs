    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int val1;
            int val2;
            int valid1 = 0;
            int valid2 = 0;
            if(int.TryParse(textBox1.Text.Trim(), out val1))
            {
                if(val1>0)
                {
                    valid1 = 1;
                    caption1.ForeColor = Color.Yellow;
                    caption1.Visible = true;
                    caption1.Text = "First value is valid"; 
                }
                else
                {
                    caption1.ForeColor = Color.Red;
                    caption1.Visible = true;
                    caption1.Text = "Value must be Greater than 0";
                }
            }
            else
            {
                caption1.ForeColor = Color.Red;
                caption1.Visible = true;
                caption1.Text = "Value must be Numeric";
            }
            if(int.TryParse(textBox2.Text.Trim(), out val2))
            {
                if (val2 > 0)
                {
                    valid2 = 1;
                    caption2.ForeColor = Color.Yellow;
                    caption2.Visible = true;
                    caption2.Text = "First value is valid";
                }
                else
                {
                    caption2.ForeColor = Color.Red;
                    caption2.Visible = true;
                    caption2.Text = "Value must be Greater than 0";
                }
            }
            else
            {
                caption2.ForeColor = Color.Red;
                caption2.Visible = true;
                caption2.Text = "Value must be Numeric";
            }
            if((valid1 > 0)&& (valid2 > 0))
            {
                label3.Visible = true;
                label3.ForeColor = Color.Yellow;
                label3.Text = Convert.ToString(val1 + val2);
            }
            else
            {
                label3.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int val1;
            int val2;
            int valid1 = 0;
            int valid2 = 0;
            if(int.TryParse(textBox1.Text.Trim(), out val1))
            {
                if (val1 > 0)
                {
                    valid1 = 1;
                    caption1.ForeColor = Color.Yellow;
                    caption1.Visible = true;
                    caption1.Text = "First value is valid";
                }
                else
                {
                    caption1.ForeColor = Color.Red;
                    caption1.Visible = true;
                    caption1.Text = "Value must be Greater than 0";
                }
            }
            else
            {
                caption1.ForeColor = Color.Red;
                caption1.Visible = true;
                caption1.Text = "Value must be Numeric";
            }
            if(int.TryParse(textBox2.Text.Trim(), out val2))
            {
                if (val2 > 0)
                {
                    valid2 = 1;
                    caption2.ForeColor = Color.Yellow;
                    caption2.Visible = true;
                    caption2.Text = "First value is valid";
                }
                else
                {
                    caption2.ForeColor = Color.Red;
                    caption2.Visible = true;
                    caption2.Text = "Value must be Greater than 0";
                }
            }
            else
            {
                caption2.ForeColor = Color.Red;
                caption2.Visible = true;
                caption2.Text = "Value must be Numeric";
            }
            if ((valid1 > 0) && (valid2 > 0))
            {
                label3.Visible = true;
                label3.ForeColor = Color.Yellow;
                label3.Text = Convert.ToString(val1 * val2);
            }
            else 
            {
                label3.Visible = false;
            }
             }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
