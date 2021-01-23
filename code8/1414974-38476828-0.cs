    public partial class Form1 : Form
    {
        private Word.Application objWord;
    
        public Form1()
        {
            InitializeComponent();
            objWord = new Word.Application();
            // ...
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Word.Find findObject = objWord.Selection.Find;
            // ...
        }
