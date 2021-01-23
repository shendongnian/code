     //Your reference to the styledButton
     private Button styledButton;
 
     private  void btn1_Click(object sender, RoutedEventArgs e)
     {
          choix_buttons(sender, e);
     }
     private  void btn2_Click(object sender, RoutedEventArgs e)
     {
          choix_buttons(sender, e);
     }
     private async void choix_buttons(object sender, RoutedEventArgs e)
     {
         //Here you can set styledButton = default styling
         Button Btn = sender as Button;
         switch (Btn.Name)
         {
              case "btn1":
                  //do something for button1's style
                  break;
              case "btn2":
                  //do something for button2's style
                  break;
         }
                  ...all the other buttons
          //And here you set the styledButton = the button that was pressed
          styledButton = Btn;
     }
