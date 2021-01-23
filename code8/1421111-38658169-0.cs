    myButton = new CmButton 
               {
                   Text = "SIGN UP| AGREE TO TERMS",
                   BackgroundColor = Color.Transparent,
                   BorderColor = Color.Transparent,
                   BorderWidth = 0,
                   TextColor = Color.White
               }
    
    Content = new StackLayout 
    {
        Children 
        {
            myButton
        }
    }
    
    myButton.Clicked += (o, e) => { 
                                     //click event handler 
                                  };
