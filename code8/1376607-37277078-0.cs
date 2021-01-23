    public class PlayerWindow : window
    {
       public event EventHandler UserClickedButton;
        
       //Here the function you call when the user click's a button
       OnClick()
       {
           //if someone is listening to the event, call it
           if(UserClickedButton != null)
              UserClieckedButton(this, EventArgs.Empty);
       }
       public void ShowSomeStuff(string stuff)
       {
          MyLabel.Content = stuff;
       }
    }
