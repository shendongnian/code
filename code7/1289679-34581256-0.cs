    public partial class Form1 : Form
    {
        private const int MinX = 0;
        private const int MaxX = 150;
        public Form1()
        {
            InitializeComponent();
            // Run "animation" in separate thread to avoid UI blocking
            Task.Run(() =>
            {
                int x = 0;
                while (true)
                {
                    if (x > MaxX)
                        x = MinX;
                    x += 1;
                    // Change must be delegated to the UI thread
                    pictureBox.Invoke((Action)(() =>
                    {
                        pictureBox.Location = new Point(x, pictureBox.Location.Y);
                    }));
                    Thread.Sleep(15);
                }
            });
        }
    }
