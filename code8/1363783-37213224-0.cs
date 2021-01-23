    using (var context = new TestDbContext())  
    {
        // Update the company and state that the company 'owns' the collection contacts, with contacts having associated advertisement options.
        context.UpdateGraph(company, map => map
            .OwnedCollection(p => p.Contacts, with => with
                .AssociatedCollection(p => p.AdvertisementOptions))
            .OwnedCollection(p => p.Addresses)
        );
    
        context.SaveChanges();
    }
