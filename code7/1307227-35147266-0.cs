    foreach (Entity item in ec.Entities)
    {
    
        if (item.Attributes.Contains("expirationdate"))
        {
            string temp1 = string.Empty;
            DateTime date;
            date = Convert.ToDateTime(item.Attributes["expirationdate"]);
            temp1 = date.Date.ToString("d");
            item.Attributes["expirationdate_hidden"] = temp1;  
        }
        service.Update(item);
    }
