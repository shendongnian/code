    public class Form2 : Form
    {
        public void ButtonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        public void ButtonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
    public class Form1 : Form 
    {
        public void Button1_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Yes) TextBox1.Text = String.Empty;   
            }
        }
    }
