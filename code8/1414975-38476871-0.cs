    public class Form1 : Form
    {
        private Word.Application _wordApplication;
        public Form1()
        {
            InitializeComponent();
            _wordApplication = new Word.Application();
            _wordApplication.Visible = true;
            var fileName = @"C:\Users\jason\Documents\Custom Office Templates\MLA1.dotx";
            var document = _wordApplication.Documents.Open(fileName, ReadOnly:false, Visible: true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var findObject = _wordApplication.Selection.Find;
            findObject.ClearFormatting();
            findObject.Text = "Name";
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = textBox1.Text;
            object replaceAll = Word.WdReplace.wdReplaceAll;
            object missing = System.Reflection.Missing.Value;
            findObject.Execute(Replace: Word.WdReplace.wdReplaceAll);
        }
    }
