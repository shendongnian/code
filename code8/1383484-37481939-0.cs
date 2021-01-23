        ModelCamwareContext localContext = new ModelCamwareContext();
        string test = dataRow["Dealer"].ToString();
        Dealer dealer = localContext.Dealers.Where(x => x.Name == test).FirstOrDefault();
        if (dealer != null)
        {
    
        }
        else
        {
    
        }
