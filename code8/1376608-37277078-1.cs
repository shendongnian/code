    public class MainWindow : Window
    {
         public MainWindow()
         {
             //we create the first window
             PlayerWindow w1 = new PlayerWindow();
             //hook to the event
             w1.UserClickedButton += Player1Clicked;
             
             //same for player 2
             PlayerWindow w2 = new PlayerWindow();
             w2.UserClickedButton += Player2Clicked;
             //open the created windows
             w1.Show();
             w2.Show();
         }
         private void Player2Clicked(object sender, EventArgs e)
         {
             //Here your code when player 2 clicks.
             w1.ShowSomeStuff("The other player clicked!");
         }
         private void Player2Clicked(object sender, EventArgs e)
         {
             //Here your code when player 1 clicks.
             w2.ShowSomeStuff("The player 1 clicked!");
         }
    }
