    public partial class Form2 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Owner).ClearRows();
            this.Close();
        }
    }
