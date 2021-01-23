    private void buttonBuyComm_Click(object sender, EventArgs e)
    {
    	int buyAmount;
    	int.TryParse(commBuyText.Text, out buyAmount);
    	int itemNumber;
    	int.TryParse(commItem.Text, out itemNumber);
    
    	if (buyAmount <= 0)
    	{
    		return;
    	}
    	else
    	{
    		addListComm();
    
    		foreach(Share s in shareList)
    		{
    			if (s.OrderNumber == itemNumber) // This is where I get the error
    			{
    				if (s.MaxShares > s.OwnedShares)
    				{
    					decimal totalSharePrice = buyAmount * s.Value;
    					if (totalSharePrice <= money)
    					{
    						money = money - totalSharePrice;
    						s.OwnedShares = s.OwnedShares + buyAmount;
    						if (s.Value > s.boughtAt)
    						{
    							s.boughtAt = s.Value;
    						}
    
    						updateLabels();
    						updateLists();
    					}
    					else
    					{
    						MessageBox.Show("You do not have enough money!");
    					}
    				}
    				else
    				{
    					MessageBox.Show("You already own all the shares!");
    				}
    			}
    		}
    	}
    }
