    ExtendedPropertyDefinition CustomProperty = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "CustomPropertyName", MapiPropertyType.String);
    PropertySet ItemPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
    ItemPropSet.Add(CustomProperty);
    EmailMessage message = EmailMessage.Bind(exchange, item.Id,ItemPropSet);
 
