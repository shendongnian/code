    public partial class DesignPar : Form
    {
        public variables var = null;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (var == null)
                var = new variables();
            textBox2.Text = var.Design;
        }
    }
