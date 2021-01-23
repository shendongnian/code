    public partial class InfoBox : UserControl
    {
        public InfoBox()
        {
            InitializeComponent();
        }
        public string Label1Text
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string Label2Text   {  get { return label2.Text; }   }
        public string TextBox1Text {  get; set;  }
        public void LoadImage(Image img)
        {
            pictureBox1.Image = img;
            if (img != null) label2.Text = img.Width + "x" + img.Height;
            else label2.Text = "no image loaded.";
        }
        public void LoadImage(string imageFileName)
        {
            LoadImage(Image.FromFile(imageFileName));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Button1Click != null) Button1Click(this);
        }
        public Button1Click Button1Click { private get; set; }
    }
    public delegate void Button1Click(InfoBox ibox);
