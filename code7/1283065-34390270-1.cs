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
    
