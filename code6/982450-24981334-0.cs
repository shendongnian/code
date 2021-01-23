    private Random rnd = new Random();
    
    private void showRandomOrb()
    {
    	switch(rnd.Next(2,19)) // selects random integer from 2 to 18
    	{
    		case 2:
    			orb2.Visibility = Visibility.Visible;
    			break;
    		case 3:
    			orb3.Visibility = Visibility.Visible;
    			break;
    		case 4:
    			orb4.Visibility = Visibility.Visible;
    			break;
    		// etc..
    		case 18:
    			orb18.Visibility = Visibility.Visible;
    			break;
    	}
    }
    
    private void o1(object sender, PointerRoutedEventArgs e)
    {
    	showRandomOrb();
    }
