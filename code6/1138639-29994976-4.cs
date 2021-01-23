    foreach (var MyLead in query)
    {
       string customerName = MyLead.Lead.CustomerName; // i.e. some property of WebLead
       DateTime InsertDate = MyLead.Pricing.InsertDate; // i.e. some property of Pricings
    }
