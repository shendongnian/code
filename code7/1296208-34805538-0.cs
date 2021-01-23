    var tenant = new Tenant(clientContext);
     SPOSitePropertiesEnumerable spp = tenant.GetSiteProperties(0, true);
     clientContext.Load(spp);
     clientContext.ExecuteQuery();
     foreach(SiteProperties sp in spp)
    {
        // you'll get your site collections here
    }
