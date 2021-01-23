        public Form1()
		{
			InitializeComponent();
			new Thread(MyDraw).Start();
		}
		private void MyDraw()
		{
			while(true)
			{
				Invoke(new Action(DrawItem));
				Thread.Sleep(1000);
			}
		}
		private void DrawItem()
		{
			using (var graphics = Graphics.FromImage(pictureBox1.Image))
			{
				graphics.DrawString("Hello", new Font("Arial", 20), Brushes.Yellow, PointF.Empty);
			}
		}
