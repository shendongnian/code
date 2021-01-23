    public class Form1
    {
        private Form2 _form2;
        public Button1_Click(object sender, EventArgs e)
        {
            if (_form2 != null)
            {
                _form2.Close();
            }
 
            _form2 = new Form2();
            _form2.Label1.Text = DateTime.Now.ToString(); // or any other actions with form
            _form2.Show();
        }
    }
