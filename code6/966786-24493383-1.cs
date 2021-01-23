    private Button currentPopupHolder;
    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
       var btn = sender as Button;
       if (currentPopupHolder != btn)
       {
          popup.IsOpen = true;
          currentPopupHolder = btn;
       }
    }
    
    private void Button_MouseLeave(object sender, MouseEventArgs e)
    {
       currentPopupHolder = null;
    }
