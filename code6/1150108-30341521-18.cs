        public Form1()
        {
            InitializeComponent();
            panel4.BackgroundImage = Gradient2D(panel4.ClientRectangle, 
                   Color.Black, Color.FromArgb(255, 0, 255, 0), Color.Red, Color.Yellow);
        }
