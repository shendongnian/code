    foreach (IPAddress address in addresses)
    {
        //Assuming this outputs the Address.                                    
        IPAddressView aView = new IPAddressView(address.ToString());
        aView.ButtonClicked += IPAddress_ButtonClicked; 
        flowLayoutPanel1.Controls.Add(aView.FlowPanel);
    }
    private void IPAddress_ButtonClicked(object sender, IPAddressView.ButtonType type)
    {
        IPAddressView aView = sender as IPAddressView;
       
        switch (type)
        {
            case IPAddressView.ButtonType.Router:
                {
                    DoSomething();
                    break;
                }
    
                ...
        }
    }
