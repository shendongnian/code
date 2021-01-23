    private void Button1_Click(object sender, RoutedEventArgs e) 
    {         
            if (isSecondClick)
    		{	
    			NewPage np = new NewPage();
                this.NavigationService.Navigate(np);            
            }
            else
            { 
                Button1.Content = "Next";
                isSecondClick = true;
            }
    }
