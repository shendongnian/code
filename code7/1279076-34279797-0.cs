     public class PlayerInfo { 
           // your stuff
           public bool IsVisible {get;set;}
           public void Toggle() {
                 if (IsVisible)
                       Hide()
                 else
                       Show()
                 IsVisible = !IsVisible
           }
     }
