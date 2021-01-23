    private void ButtonBase_OnClickdot(object sender, RoutedEventArgs e)
        {
            CalculateTextBlock.Text += Buttondot.Content.ToString(); //You have it here
            ShowTextBlock.Text += Buttondot.Content.ToString();
        }
        private void ButtonBase_OnClickobrac(object sender, RoutedEventArgs e)
        {
            CalculateTextBlock.Text += Buttonobrac.Content; //Add .ToString() 
            ShowTextBlock.Text += Buttonobrac.Content.ToString();
        }
