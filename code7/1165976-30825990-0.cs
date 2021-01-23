    public class Form2 : Form
    {
        public bool Result { get; set; }
    
        public void ButtonYes_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }
        public void ButtonNo_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }
    }
    public class Form1 : Form 
    {
        public void Button1_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                 form.ShowDialog();
                 if (form.Result) TextBox1.Text = String.Empty;   
            }
        }
    }
