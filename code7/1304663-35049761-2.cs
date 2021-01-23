    public partial class myWindow : Form
    {
        private int _roll;
        private int _numGuesses;
        public Window()
        {
            InitializeComponent();
            Random random = new Random();
            _roll = random.Next(0, 99);
        }
        private void guessButton_Click(object sender, EventArgs e)
        {
            bool isGuessCorrect = // Set this however you need to
            if (isGuessCorrect)
            {
                // They got it right!
            }
            else
            {
                _numGuesses++;
                if (_numGuesses > 9)
                {
                    // Tell them they failed
                }
                else
                {
                    // Tell them they're wrong, but have 10 - _numGuesses guesses left
                }
            }
        }
    }
