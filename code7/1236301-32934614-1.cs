    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(@"d:\test.html");
        }
        private void clickToolStripButton_Click(object sender, EventArgs e)
        {
            var frame = this.webBrowser1.Document.GetElementById("iframeid").Document.Window.Frames["iframeid"];
            var button = frame.Document.GetElementById("buttonid");
            button.InvokeMember("onclick");
        }
    }
