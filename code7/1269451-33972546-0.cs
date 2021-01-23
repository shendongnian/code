    private void pOneColorChoice(object sender, SelectionChangedEventArgs e)
        {
           setPlayerOneColor = PlayerOneColor.SelectedItem; 
           Frame.Navigate(typeof(Page2), setPlayerOneColor);
        }
