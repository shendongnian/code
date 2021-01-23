    for (int i = lstSalesPerson.Items.Count-1; i >=0 ; i--)
    {
    
                if (lstSalesPerson.Items[i].Selected == true)
                {
                    if (items.Count() > 4)
                    {
                        Label1.Text = "checked maximum 4 items.";                      
                        lstSalesPerson.Items[i].Selected = false;
                    }
                }
            }  
    
