    modelBuilder.Entity<ContactLinkCustomer>()
                .Map(m =>
                {
                    m.Properties(e => e.Tenant_ID);
                    m.ToTable("ContactLinkCustomer");
                });
    
    Unhandled Exception: System.NotSupportedException: The type 'ContactLinkCustomer' cannot be mapped as defined because it maps inherited properties from types th
    at use entity splitting or another form of inheritance. Either choose a different inheritance mapping strategy so as to not map inherited properties, or change
    all types in the hierarchy to map inherited properties and to not use splitting.
