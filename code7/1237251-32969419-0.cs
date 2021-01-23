    public partial class Form1 : Form
    {
        Keys lastkeyPressed = Keys.Enter;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (lastkeyPressed == Keys.A)
            {
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    int vA = 0;
                    int.TryParse(textBox1.Text, out vA);
                    vA += 5;
                    textBox1.Text = (String)vA.ToString();
                }
            }
            if (lastkeyPressed == Keys.B)
            {
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    int vB = 0;
                    int.TryParse(textBox2.Text, out vB);
                    vB += 5;
                    textBox2.Text = (String)vB.ToString();
                }
            }
            if (lastkeyPressed == Keys.C)
            {
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    int vC = 0;
                    int.TryParse(textBox3.Text, out vC);
                    vC += 5;
                    textBox3.Text = (String)vC.ToString();
                }
            }
            lastkeyPressed = e.KeyCode;
        } 
    }
