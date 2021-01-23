    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vScrollBar1.Value = vScrollBar1.Maximum / 2;
            ChangeTextBoxValues(vScrollBar1.Maximum / 2, vScrollBar1.Value);
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int avg = vScrollBar1.Maximum / 2;
            ChangeTextBoxValues(avg, e.NewValue);
        }
        void ChangeTextBoxValues(int AvgValue, int NewValue)
        {
            textBox1.Text = (AvgValue - NewValue).ToString();
            textBox2.Text = (NewValue - AvgValue).ToString();
        }
    }
