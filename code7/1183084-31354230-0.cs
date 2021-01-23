    public partial class Form1 : Form
    {
        public static TabPage[] TabPages = new TabPage[20];
        public static RichTextBox[] TextBoxes = new RichTextBox[20];
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Clear();
            for (int x = 0; x < 19; x++)
            {
                TabPages[x] = new TabPage();
                TabPages[x].Controls.Add(TextBoxes[x]);    //ERROR HERE
                //Object reference not set to an instance of an object.
                tabControl1.TabPages.Add(TabPages[x]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
