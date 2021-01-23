    public partial class Form1 : Form {
        private WebBrowser webBrowser1;
        private Button button1;
        public Form1() {
            button1 = new Button { Text = "Test" };
            button1.Click += button1_Click;
            this.Controls.Add(button1);
            webBrowser1 = new WebBrowser { Dock = DockStyle.Fill };
            webBrowser1.DocumentText = @"<html><body><textarea class=""myStudentInput"" id=""myStudentInput1"">Text to be copied</textarea></body></html>";
            this.Controls.Add(webBrowser1);
        }
        private void button1_Click(object sender, EventArgs e) {
            var elem = webBrowser1.Document.GetElementById("myStudentInput1");
            MessageBox.Show(elem.InnerText);
        }
    }
