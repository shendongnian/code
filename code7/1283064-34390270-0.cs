        You need to refresh the collection after removing element. 
    Try to change your code like below and see if its work
        
        var newList = invo;
        foreach (IGrouping<string, InvoiceCount> invoice in invo)
        {
               for (var line = 1; line < invoice.Count(); line++)                
               {
                   if (YOUR CONDITION HERE)
                   {
                      newList.Remove(invoice );
                      invo= newList;
                   }
               }
        }
        
        NOTE: https://topherlandry.wordpress.com/2013/05/14/how-to-modify-a-collection-during-iteration-in-c/
