    private static IEnumerable<string> GetBaseAddresses()
    {
        // Get the application configuration file.
        // TODO: Might be adjusted for WCF hosted / web.config
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        // Get the collection of the section groups.
        var sectionGroups = config.SectionGroups;
        // Get the serviceModel section
        var serviceModelSection = sectionGroups.OfType<ServiceModelSectionGroup>().SingleOrDefault();
        // Check if serviceModel section is configured
        if (serviceModelSection == null)
            throw new ArgumentNullException("Configuration section 'system.serviceModel' is missing.");
        // Get base addresses
        return (from ServiceElement service in serviceModelSection.Services.Services
                from BaseAddressElement baseAddress in service.Host.BaseAddresses
                select baseAddress.BaseAddress);
    }
