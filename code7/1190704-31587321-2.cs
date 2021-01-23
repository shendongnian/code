    public class PopupForm : Form
    {
        public bool Referansyaz { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Referansyaz = true;
            Close();
        }
        // rest of form
        ...
    }
