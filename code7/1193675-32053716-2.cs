        public Form1() {
            InitializeComponent();
            pictureBox1.Image = CreateAnimation(pictureBox1,
                new Image[] { Properties.Resources.Frame1, Properties.Resources.Frame2, Properties.Resources.Frame3 },
                new int[] { 1000, 2000, 300 });
        }
