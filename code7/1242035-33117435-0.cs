    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace TicTacToe
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            Random random = new Random();
    
            int firstPlayer = 0;
            bool turn;
            bool winner = true;
            string playerX;
            string playerO;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void ResetBoard ()
            {
                //Clear Xs & Os:
                buttonTopLeft.Content = "";
                buttonMiddleTop.Content = "";
                buttonTopRight.Content = "";
    
                buttonMiddleLeft.Content = "";
                buttonMiddle.Content = "";
                buttonMiddleRight.Content = "";
    
                buttonLowerLeft.Content = "";
                buttonMiddleBottom.Content = "";
                buttonBottomRight.Content = "";
    
                //make board playable
                winner = false;
    
                //reset background colors
                buttonTopLeft.Background = Brushes.LightGray;
                buttonMiddleTop.Background = Brushes.LightGray;
                buttonTopRight.Background = Brushes.LightGray;
                buttonMiddleLeft.Background = Brushes.LightGray;
                buttonMiddle.Background = Brushes.LightGray;
                buttonMiddleRight.Background = Brushes.LightGray;
                buttonLowerLeft.Background = Brushes.LightGray;
                buttonMiddleBottom.Background = Brushes.LightGray;
                buttonBottomRight.Background = Brushes.LightGray;
    
            }
    
            private void ChooseFirstPlayer ()
            {
                if (textBoxPlayerO.Text == "Audra")
                {
                    turn = false;
                    playerX = textBoxPlayerX.Text;
                    playerO = textBoxPlayerO.Text;
                    textBlockGameInfo.Text = playerO + " goes first";
                }
                else if (textBoxPlayerX.Text == "Audra")
                {
                    turn = true;
                    playerX = textBoxPlayerX.Text;
                    playerO = textBoxPlayerO.Text;
                    textBlockGameInfo.Text = playerX + " goes first";
                }
                else
                {
                    firstPlayer = random.Next(1, 3);
    
                    if (textBoxPlayerO.Text == "" || textBoxPlayerX.Text == "")
                    {
                        textBlockGameInfo.Text = "Please enter both player's names";
                    }
                    else
                    {
    
                        if (firstPlayer == 1)
                        {
                            turn = true;
                            playerX = textBoxPlayerX.Text;
                            playerO = textBoxPlayerO.Text;
                            textBlockGameInfo.Text = playerX + " goes first";
                        }
                        else if (firstPlayer == 2)
                        {
                            turn = false;
                            playerX = textBoxPlayerX.Text;
                            playerO = textBoxPlayerO.Text;
                            textBlockGameInfo.Text = playerO + " goes first";
                        }
                    }
                }
    
                }
    
            private void buttonStartGame_Click(object sender, RoutedEventArgs e)
            {
                ResetBoard();
                ChooseFirstPlayer();
            }
    
            private void IsNoWinner ()
            {
                if (buttonTopLeft.Content != "" && buttonMiddleTop.Content != "" && buttonTopRight.Content != "" &&
                    buttonMiddleLeft.Content != "" && buttonMiddle.Content != "" && buttonMiddleRight.Content != "" &&
                    buttonLowerLeft.Content != "" && buttonMiddleBottom.Content != "" && buttonBottomRight.Content != "" && winner == false)
                {
                    textBlockGameInfo.Text = "It's a draw!";
                }
            }
    
            private void IsXWinner ()
            {
                if (buttonTopLeft.Content == "X" && buttonMiddleTop.Content == "X" && buttonTopRight.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddleTop.Background = Brushes.LightPink;
                    buttonTopRight.Background = Brushes.LightPink;
                }
                else if (buttonMiddleLeft.Content == "X" && buttonMiddle.Content == "X" && buttonMiddleRight.Content =="X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                }
                else if (buttonLowerLeft.Content == "X" && buttonMiddleBottom.Content == "X" && buttonBottomRight.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonMiddleLeft.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonMiddleRight.Background = Brushes.LightPink;
                }
                else if (buttonTopLeft.Content == "X" && buttonMiddleLeft.Content == "X" && buttonLowerLeft.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddleLeft.Background = Brushes.LightPink;
                    buttonLowerLeft.Background = Brushes.LightPink;
                }
                else  if (buttonMiddleTop.Content == "X" && buttonMiddle.Content == "X" && buttonMiddleBottom.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonMiddleTop.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonMiddleBottom.Background = Brushes.LightPink;
                }
                else if (buttonLowerLeft.Content == "X" && buttonMiddleBottom.Content == "X" && buttonBottomRight.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonLowerLeft.Background = Brushes.LightPink;
                    buttonMiddleBottom.Background = Brushes.LightPink;
                    buttonBottomRight.Background = Brushes.LightPink;
                }
                else if (buttonTopLeft.Content == "X" && buttonMiddle.Content == "X" && buttonBottomRight.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonBottomRight.Background = Brushes.LightPink;
                }
                else if (buttonTopRight.Content == "X" && buttonMiddle.Content == "X" && buttonLowerLeft.Content == "X")
                {
                    textBlockGameInfo.Text = playerX + " is the winner!";
                    winner = true;
                    buttonTopRight.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonLowerLeft.Background = Brushes.LightPink;
                }
    
    
            }
    
            private void IsOWinner()
            {
                if (buttonTopLeft.Content == "O" && buttonMiddleTop.Content == "O" && buttonTopRight.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddleTop.Background = Brushes.LightPink;
                    buttonTopRight.Background = Brushes.LightPink;
                }
                else if (buttonMiddleLeft.Content == "O" && buttonMiddle.Content == "O" && buttonMiddleRight.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonMiddleLeft.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonMiddleRight.Background = Brushes.LightPink;
                }
                else if (buttonLowerLeft.Content == "O" && buttonMiddleBottom.Content == "O" && buttonBottomRight.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                }
                else if (buttonTopLeft.Content == "O" && buttonMiddleLeft.Content == "O" && buttonLowerLeft.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddleLeft.Background = Brushes.LightPink;
                    buttonLowerLeft.Background = Brushes.LightPink;
                }
                else if (buttonMiddleTop.Content == "O" && buttonMiddle.Content == "O" && buttonMiddleBottom.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonMiddleTop.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonMiddleBottom.Background = Brushes.LightPink;
                }
                else if (buttonLowerLeft.Content == "O" && buttonMiddleBottom.Content == "O" && buttonBottomRight.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonLowerLeft.Background = Brushes.LightPink;
                    buttonMiddleBottom.Background = Brushes.LightPink;
                    buttonBottomRight.Background = Brushes.LightPink;
                }
                else if (buttonTopLeft.Content == "O" && buttonMiddle.Content == "O" && buttonBottomRight.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonTopLeft.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonBottomRight.Background = Brushes.LightPink;
                }
                else if (buttonTopRight.Content == "O" && buttonMiddle.Content == "O" && buttonLowerLeft.Content == "O")
                {
                    textBlockGameInfo.Text = playerO + " is the winner!";
                    winner = true;
                    buttonTopRight.Background = Brushes.LightPink;
                    buttonMiddle.Background = Brushes.LightPink;
                    buttonLowerLeft.Background = Brushes.LightPink;
                }
            }
    
            private void PlayButton(Button buttonClicked)
            {
                if (buttonClicked.Content == "")
                {
                    if (turn == true)
                    {
                        textBlockGameInfo.Text = "It is " + playerO + "'s turn";
                        buttonClicked.Content = "X";
                        turn = false;
                    }
                    else
                    {
                        textBlockGameInfo.Text = "It is " + playerX + "'s turn";
                        buttonClicked.Content = "O";
                        turn = true;
                    }
                }
                    
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                if (winner != true)
                {
                    var button = sender as Button;
    
                    PlayButton(button);
                    IsXWinner();
                    IsOWinner();
                    IsNoWinner();
                }
            }
        }
    }
