        public Form2()
        {
            InitializeComponent();
            // Assign an image to the button.
            Printbutton.Image = Image.FromFile("D:\\Downloads\\print.png");
            // Align the image and text on the button.
            Printbutton.ImageAlign = ContentAlignment.MiddleRight;
            Printbutton.TextAlign = ContentAlignment.MiddleLeft;
            // Give the button a flat appearance.
            Printbutton.FlatStyle = FlatStyle.Flat;
        }
        private void Printbutton_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
                printDocument1.Print();
        }
