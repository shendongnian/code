    using (var GC = new GroundCommanderEntities())
    {
        PAYMENT_Repo PAYMENTREPO = new PAYMENT_Repo(); 
        var ExistingCashPayment = GC.PAYMENT_Repo
            .Where(Filter => Filter.Type == "Cash" && Filter.Machine == "Tablet").ToList();
    
        string type = "";
        var amt = 0.00m;
    
        foreach (var item in ExistingCashPayment)
        {
            type = item.Type;
            amt = item.Amount;
        }
    
        if (type == cbPaymentType.Text) //a combobox that contains Types 
        {
            PAYMENTREPO.Amount = amt + Convert.ToDecimal(txtTendering.Text);                    
            // add your NEW entity to the context!
            // depending on which exact version of EF you're using, this
            // might be called `.Add()` or `.AddObject()`
            // Also, the name "PAYMENTREPOs" is just a guess - it might be 
            // different in your concrete case - adapt as needed!
            GC.PAYMENTREPOs.Add(PAYMENTREPO);
            GC.SaveChanges();
    
            return true;
         }
         else
         {
             return false;
         }             
    }
