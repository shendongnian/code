    public void DeleteClicked(object sender, EventArgs e)  
    {  
       var item = (Xamarin.Forms.Button)sender;  
       Item listitem = (from itm in allItems 
                        where itm.ItemName == item.CommandParameter.ToString() 
                        select itm)
                       .FirstOrDefault<Item>();  
       allItems.Remove(listitem);  
    }  
