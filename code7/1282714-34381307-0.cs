    //Deserialise data 
    ProcessOrdersActive details = JsonConvert.DeserializeObject<ProcessOrdersActive>(responseBody);
    
    var ordersList = new List<ProcessOrdersActive>(); 
    ordersList.Add(details); 
    int numofitems = details.ProcessOrderNbr.Count;//If this is a list use Count. If it is an array use Length 
    txtActiveOrders.Text = numofitems.ToString();
    
    for (int i = 0; i < numofitems; i++) {
         comboBoxOrders.Items.Add (details.ProcessOrderNbr[i]); 
    }
