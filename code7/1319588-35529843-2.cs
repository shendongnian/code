    public partial class MainScoreBoard : Window
    {
        public MainScoreBoard()
        {
            InitializeComponent();
        }
        static bool IsTextAllowed(string text, int num)
        {
            Regex regex = new Regex("[^0-9.-]+");
            if (!regex.IsMatch(text))
            {
                num = Int32.Parse(text);
                return true;
            }
            else return false;
        }
        void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            // You should get in the habit of initializing your variables
            int currentScore = 0, currentPlayerScore, currentResult, legs, sets;
            bool Player1Turn = true;
            // You were getting null reference exceptions from attempting to access the Content property
            // without them ever getting set.  You can initialize them with default values in the xaml or in the
            // constructor on initialization (After InitializeComponent() call).
            if (Player1Score.Content != null && Player2Score.Content != null)
            {
                bool isGameOver = false;
                // This will loop infinitely if you don't fix the bugs in calculating the score, I put a comment on it as you are not getting a value for currentScore from anywhere
                while (Int32.Parse(Player1Score.Content.ToString()) != 0 || Int32.Parse(Player2Score.Content.ToString()) != 0)
                {
                    if (IsTextAllowed(CurrentNumber.Text, currentScore))
                    {
                        if (currentScore > 180)
                        {
                            MessageBox.Show("Написаното е над 180!!!");
                            continue;
                        }
                        if (Player1Turn)
                        {
                            Player1Turn = false;
                            currentPlayerScore = Int32.Parse(Player1Score.Content.ToString());
                            // The currentScore variable is never getting set, I initialized it for you but
                            // it needs to be assigned a value from somewhere otherwise it will always be
                            // currentResult = currentPlayerScore - 0
                            currentResult = currentPlayerScore - currentScore;
                            if (currentResult < 0)
                            {
                                MessageBox.Show("Предобри!!!");
                                continue;
                            }
                            else if (currentResult == 0)
                            {
                                MessageBox.Show("Game Over!!!");                                
                                legs = Int32.Parse(Player1Legs.Content.ToString());
                                legs++;
                                Player1Legs.Content = legs.ToString();
                                if (legs == 3)
                                {
                                    //increas sets
                                    //if sets == 3, end game and shut down app 
                                }
                                //Application.Current.Shutdown();                             
                                
                                // Set flag so we do not keep looping through game over code
                                isGameOver = true;
                            }
                            Player1Score.Content = currentResult.ToString();
                            // Added this check here because I'm assuming you would want Player1Score to be reflected first
                            // before exiting the loop.
                            if (isGameOver)
                            {
                                // game is over, we do not want to keep showing the Game Over message box
                                break;
                            }
                        }
                        else
                        {
                            //the same for Player2
                            Player1Turn = true;
                        }
                    }
                }               
            }
        }
    }
