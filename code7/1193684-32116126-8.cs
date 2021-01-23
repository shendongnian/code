        public Form1()
        {
            InitializeComponent();
            
            var frame1 = Image.FromFile(@"1.png");
            var frame2 = Image.FromFile(@"2.png");
            var animatedBitmap= new AnimatedBitmap(
                new Sequence {Image = frame1, Delay = 33},
                new Sequence {Image = frame2, Delay = 33}
                );
            // or we can do
            //animatedBitmap = AnimatedBitmap.CreateAnimation(new[] {frame1, frame2}, new[] {1000, 2000});
            pictureBox1.SetAnimatedBackground(animatedBitmap);
            button1.SetAnimatedBackground(animatedBitmap);
            label1.SetAnimatedBackground(animatedBitmap);
            checkBox1.SetAnimatedBackground(animatedBitmap);
            //or we can do
            //pictureBox1.BackgroundImage = animatedBitmap;
            //pictureBox1.StartAnimation();
        }
