    public partial class Form1 : Form
    {
        int randCode;
        int[] codes = { 39835, 72835, 49162, 29585, 12653, 87350, 74783};
        ...
        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random mRandom = new Random();
            randcode = mRandom.Next(0, codes.Length);
        }
        ...
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtCode.Text) == randcode)
            {
                MessageBox.Show("working");  
            }
        }
        ...
    }
