    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GameUpdate));
            }
    
            private bool leftPressed;
            private bool rightPressed;
            private bool upPressed;
            private bool downPressed;
    
            private void GameUpdate(object state)
            {
                bool gameRunning = true;
    
                do
                {
                    if (leftPressed)
                    {
                        BeginInvoke(new Action(() => { lblCar.Location = new Point(lblCar.Location.X - 1, lblCar.Location.Y); }));
                    }
                    if (rightPressed)
                    {
                        BeginInvoke(new Action(() => { lblCar.Location = new Point(lblCar.Location.X + 1, lblCar.Location.Y); }));
                    }
                    if (upPressed)
                    {
                        BeginInvoke(new Action(() => { lblCar.Location = new Point(lblCar.Location.X, lblCar.Location.Y - 1); }));
                    }
                    if (downPressed)
                    {
                        BeginInvoke(new Action(() => { lblCar.Location = new Point(lblCar.Location.X, lblCar.Location.Y + 1); }));
                    }
    
                    Thread.Sleep(33); // 30 frames per second
                } while (gameRunning);
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: leftPressed = true; break;
                    case Keys.Right: rightPressed = true; break;
                    case Keys.Up: upPressed = true; break;
                    case Keys.Down: downPressed = true; break;
                    default: break;
                }
            }
    
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: leftPressed = false; break;
                    case Keys.Right: rightPressed = false; break;
                    case Keys.Up: upPressed = false; break;
                    case Keys.Down: downPressed = false; break;
                    default: break;
                }
            }
        }
