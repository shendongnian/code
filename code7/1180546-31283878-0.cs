    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    NetSectionGroup netSection = (NetSectionGroup)config.GetSectionGroup("system.net");
    if (string.IsNullOrEmpty(model.ProxyUrl))
	    netSection.DefaultProxy.Enabled = false;
    else
	    netSection.DefaultProxy.Enabled = true;
