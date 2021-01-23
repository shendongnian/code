     private void btnsubmit_Click(object sender, RoutedEventArgs e)
    {
    	double principal;
    	double years;
    	double intrate;
    //Validate radio button
    	if (rad10years.IsChecked == true)
    	{
    		years = 10;
    		return;
    	}
    	else if (rad20years.IsChecked == true)
    	{
    		years = 20;
    		return;
    	}
    	else if (rad30years.IsChecked == true)
    	{
    		years = 30;
    		return;
    	}
    	else if (radother.IsChecked == true)
    	{
    		if(!double.TryParse(txtother.Text, out years))
    		{
    		    MessageBox.Show("Not a valid year");    
    		}
    		return;
    	}
    	else
    	{
    	    MessageBox.Show("your message here"); // use message you want to show/prompt.
          	stkrdobtns.Background = new SolidColorBrush(Colors.Red);
    		return;
    	}
    }
