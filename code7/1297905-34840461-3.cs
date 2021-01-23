    [ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentText =
            @"<html>
            <head>
            <title>Test</title>
            <script>
                function someJSMethod(value){alert(value);}
            </script>
            </head>
            <body>
                <input type=""text"" id=""text1""/>
                <br/>
                <input type=""button"" value=""Call C# Method"" id=""button1""
                onclick=""window.external.SomeCSMethod('Method called from JavaScript');""/>
                <br/>
                <input type=""button"" value=""Set WinForms Control Value"" id=""button2""
                onclick=""window.external.textBox1.Text='Value set from JavaScript';""/>
            </body>
            </html>";
            this.webBrowser1.ObjectForScripting = this;
        }
        public void SomeCSMethod(string value)
        {
            MessageBox.Show(value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Document
                            .InvokeScript("someJSMethod", new[] { "Method called from C#" });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Document.GetElementById("text1")
                                     .SetAttribute("value", "Value set from C#");
        }
    }
