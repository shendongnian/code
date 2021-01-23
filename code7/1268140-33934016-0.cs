    foreach (RepeaterItem item in Repeater1.Items)
    {
         var TeklifId = (Label)item.FindControl("TeklifId");
         if (TeklifId == 1)
         {
             //do something
         }
    }
