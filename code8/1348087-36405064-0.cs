    public partial class Form1 : Form
    {
        private Block[] _block = new Block[50];
        private Point _x = new Point(0, 50);
        private  Timer _timer=new Timer();
        private int _index = 0;
    
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            for (int i = 0; i < 50; i++)
            {
                _block[i] = new Block(_x);
                 //Move the position of the block
                ChangeXLoc();
                Controls.Add(_block[i]._ScreenPanel());
                label1.Text = @"Generating block [" + i + @"]";
            }
        }
        //Timer to spawn the blocks
        private void _timer_Tick(object sender, EventArgs e)
        {
            _block[_index].SpawnBlock();
            if (_index < 49)
                _index++;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Start();
        }
    
        private void ChangeXLoc()
        {
            _x.X += 50;
        }
    }
