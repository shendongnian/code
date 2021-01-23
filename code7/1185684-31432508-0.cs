     CultureInfo provider = new CultureInfo("en-US");
     Object[] myrow = new Object[QuotationDG.Columns.Count];
    
     for (int i = 0; i < QuotationDG.Columns.Count; i++ )
     {
           myrow[i] = Convert.ChangeType("0", typeof(object), provider);
           //i++;
     }
