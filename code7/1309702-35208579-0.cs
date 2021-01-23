    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        private const int totalPoints = 60 + 15; // sum of each trait plus the pool bonus
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                if (control is NumericUpDown)
                {
                    NumericUpDown numControl = control as NumericUpDown;
                    numControl.Minimum = 7;
                    numControl.Maximum = 18;
                    numControl.Value = 10;
                    numControl.ValueChanged += nud_ValueChanged;
                    lblPointsLeft.Text = "15"; // bonus points
                }
            }
        }
        private void nud_ValueChanged(object sender, EventArgs e)
        {
            int sum = (int)(nudCha.Value + nudCon.Value + nudDex.Value + nudInt.Value + nudStr.Value + nudWis.Value);
            int pointsLeft = totalPoints - sum;
            NumericUpDown nudSender = (NumericUpDown)sender;
            if (pointsLeft < 0)
            {
                MessageBox.Show("No points left");
                // restore last change
                // undo the last change 
                nudSender.Value = nudSender.Value - 1;
                pointsLeft++;
            }
            lblPointsLeft.Text = pointsLeft.ToString();
        }
    }
    }
