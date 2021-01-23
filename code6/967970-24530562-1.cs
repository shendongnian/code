        // Define MAPI extended properties
        private readonly ExtendedPropertyDefinition _extendedPropEventId = 
            new ExtendedPropertyDefinition(
                new Guid("{00020329-0000-0000-C000-000000000046}"),
                "Event Identifier",
                MapiPropertyType.String);
        private readonly ExtendedPropertyDefinition _extendedPropBlah = 
            new ExtendedPropertyDefinition(
                new Guid("{00020329-0000-0000-C000-000000000046}"),
                "Blah",
                MapiPropertyType.String);
    ...
        // Set extended properties for appointment
        calendar.SetExtendedProperty(_extendedPropEventId, "custom EventID value");
        calendar.SetExtendedProperty(_extendedPropBlah, "custom Blah value");
    ...
        // Bind to existing item for reading extended properties
        var propertySet = new PropertySet(BasePropertySet.FirstClassProperties, _extendedPropEventId, _extendedPropBlah);
        var calendar = Appointment.Bind(p_service, itemId, propertySet);
        if (calendar.ExtendedProperties.Any(ep => ep.PropertyDefinition.PropertySetId == _extendedPropEventId.PropertySetId))
        {
            // Add your code here...
        }
