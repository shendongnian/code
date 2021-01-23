    public class FormA : Form
    {
        public void start()
        {
            FormB b = new FormB(this.textBox.Text);
        }
    }
    public class FormB : Form
    {
        public FormB(string s)
        {
            // use variable s
        }
    }
