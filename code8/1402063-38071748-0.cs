     var buttonBackground = myButton.Background;
     var backgroundColor = Color.Empty;
        if(buttonBackground is ColorDrawable)
          {
             backgroundColor = (buttonBackground as ColorDrawable).Color;
             //You now have a background color.
          }
    
    if(backgroundColor != Color.Empty)
       RegEmail.SetBackgroundColor(backgroundColor);
