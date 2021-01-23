    [ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.ObjectForScripting = this;
        }
    }
