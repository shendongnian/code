    private void on_Country_Selection(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count>0)
            {
                country = e.AddedItems[0] as Country;
                PhoneApplicationService.Current.State("COUNTRY") = country;
                   //close the page
                
                  
    
            }
        }
