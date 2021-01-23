    using (var context = new OrganizationServiceContext(_serviceProxy))
    {
        var quote = new Quote
        {
            QuoteNumber = "123",
            Name = "test123",
            PriceLevelId = new EntityReference(PriceLevel.EntityLogicalName, pricelevel.Id),
            CustomerId = new EntityReference(Account.EntityLogicalName, customer.Id),
        };
        context.AddObject(quote);
    
        var quoteDetail = new QuoteDetail
        {
            ProductId = new EntityReference(Product.EntityLogicalName, product.Id),
            IsPriceOverridden = true,
            PricePerUnit = new Money(20),
            Quantity = Convert.ToDecimal(5),
        };
        context.AddRelatedObject(quote, new Relationship("quote_details"), quoteDetail);
    
        context.SaveChanges();
    }
