    private void btnchgcolour_Click(object sender, RoutedEventArgs e)
    {
        MainWindow m1 = (MainWindow)this.Parent;
        //if does not work use this.Owner;
    	if(rdbred.IsChecked == true)
    	{
    		m1.BirdColor = "redbird";
    	}
    	else if(rdbgreen.IsChecked == true)
    	{
    		m1.BirdColor = "greenbird";
    	}
    	else if(rdbblack.IsChecked == true)
    	{
    		m1.BirdColor = "blackbird";
    	}
    }
    private void btnback_Click(object sender, RoutedEventArgs e)
    {
            MainWindow m1 = (MainWindow)this.Parent;
            //if does not work use this.Owner;
            m1.Show();
            this.Close();
    }
