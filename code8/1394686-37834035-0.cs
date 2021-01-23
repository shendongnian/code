    public class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            using(var form2 = new Form2())
            {
                // if you want to fill the username before popup..
                // do it here:
                // form2.UserName = textBox2.Text;
                var result = form2.ShowDialog();
                if(result != DialogResult.OK)
                    return;
                username = form2.UserName;
            }
            textBox2.Text = username;
        }
    }
    public class Form2 : Form
    {
        public string UserName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
