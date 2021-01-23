    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	var client = new Service1Client();
    	client.GetDataCompleted += client_GetDataCompleted;
    	client.GetDataAsync();
    
    }
    
    private void client_GetDataCompleted(object sender, GetDataCompletedEventArgs e)
    {
    	//here I inspected the results and even the Items property of PriceHeader objects were properly filled
    	var results = e.Result as IEnumerable<PriceHeader>;
    	
    	//not sure if this is necessary here
    	(sender as Service1Client).CloseAsync();
    }
