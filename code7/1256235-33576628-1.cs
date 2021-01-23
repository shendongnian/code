    public partial class Form1 : Form
    {
        // Leave the seed alone on this line
        private readonly Random _r = new Random();
        // these need to be outside of your Click event
        private int _counterFlips;
        private int _heads;
        private int _lives = 20;
        public Form1()
        {
            InitializeComponent();
        }
        private void cmdFlipCoin_Click(object sender, EventArgs e)
        {
            // x = starting number, y = ending number + 1
            // This should be either a zero or one:
            int rand = _r.Next(0, 2);
            switch (rand)
            {
                default:
                    _lives --;
                    _counterFlips++;
                    break;
                case 1:
                    _heads ++;
                    _counterFlips++;
                    break;
            }
            lblFlips.Text = @"Flips = " + _counterFlips;
            lblHeads.Text = @"Heads = " + _heads;
            lblLivesLeft.Text = @"Lives Left = " + _lives;
            if (_lives < 1)
            {
                MessageBox.Show(@"sorry you are out of lives m8");
                button1.Enabled = false;
            }
        }
