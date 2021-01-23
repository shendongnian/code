    string targetList = (this.Properties["TargetList"] ?? string.Empty).ToString();
    using (SPSite site = new SPSite(targetSite))
    {
       using (SPWeb web = site.OpenWeb())
       {
       //TO DO
       }
    }
