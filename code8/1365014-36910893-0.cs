        public Form1()
        {
            InitializeComponent();
            // Assign an image to the button.
            button1.Image = Image.FromFile("C:\\Yourfolder");
            // Align the image and text on the button.
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.TextAlign = ContentAlignment.MiddleLeft;
            // Give the button a flat appearance.
            button1.FlatStyle = FlatStyle.Flat;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Your print code.
        }
  
