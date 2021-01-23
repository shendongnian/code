    public class Form1:Form
    {
        public Form2 MyFrom { get; set; }
        public void From_Load ( object sender ,EventArgs e)
        {
            MyForm = new Form2();
            MyForm.Show();
        }
        public void btn_Click ( object sender ,EventArgs e)
        {
            MyForm.btn.Visible = true;
        }
    }
