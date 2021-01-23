    private static void _button_Click(object sender, RoutedEventArgs e)
    {
        Button Clicked = (Button)sender;
        foreach(Button btn in menuButtons)
        {
            if (Clicked.Name == btn.Name)
            {
                 btn.Background = myFunkyColour;
            }
            else
            {
                btn.Background = //Your Disabled Colour.
            }
        }
    }
