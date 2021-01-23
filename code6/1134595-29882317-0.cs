    public partial class Form1 : Form
    {
        // A user is allowed a maximum of 3 guesses per label.
        private const int MaxTries = 3;
        // The number of guesses for the current label.
        private int _triesOnCurrentLabel;
        // The number of labels guessed correctly so far.
        // This is also the index into the patterns list.
        private int _numberGuessedRight;
        // The game is over if the user guessed all labels
        // or used more than the maximum number of tries on a label.
        private bool _gameOver;
        // ... other stuff
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (!_gameOver)
            {
                if (pattern[_numberGuessedRight] == clickedLabel)
                {
                    // The user guessed right.
                    _triesOnCurrentLabel = 0; // reset, 3 tries for next label.
                    _numberGuessedRight++;
                    _gameOver = _numberGuessedRight == pattern.Count;
                    if (_gameOver)
                    {
                        // Show the user a message? "YOU WON"
                    }
                }
                else if (++_triesOnCurrentLabel >= MaxTries)
                {
                    // User used up all tries on the current label.
                    _gameOver = true;
                    // Show the user a message? "Game over YOU LOSER"
                }
            }
        }
        // ... the rest
    }
