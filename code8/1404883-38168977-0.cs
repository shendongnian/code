        PropertySet AllProps = new PropertySet(BasePropertySet.FirstClassProperties);
        NameResolutionCollection ncCol = service.ResolveName("User@domain.com", ResolveNameSearchLocation.DirectoryOnly, true, AllProps);
        foreach (NameResolution nr in ncCol)
        {
            Console.WriteLine(nr.Contact.Notes);
        }
