    public class PopupForm : Form
    {
        private Form1 f1;
        public PopupForm(Form1 f1)
        {
            this.f1 = f1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f1.referansyaz = true;
            Close();
        }
        // rest of form
        ...
    }
