        public Form1()
        {
            InitializeComponent();
            panel.BackgroundImage = Gradient2D(panel.ClientRectangle, 
                   Color.Black, Color.FromArgb(255, 0, 255, 0), Color.Red, Color.Yellow);
        }
