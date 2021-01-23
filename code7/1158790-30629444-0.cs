    var guid = new Guid("0006200E-0000-0000-C000-000000000046");
    var colour = new ExtendedPropertyDefinition(guid, 0x8B00, MapiPropertyType.Integer);
    var width = new ExtendedPropertyDefinition(guid, 0x8B02, MapiPropertyType.Integer);
    var height = new ExtendedPropertyDefinition(guid, 0x8B03, MapiPropertyType.Integer);
    var left = new ExtendedPropertyDefinition(guid, 0x8B04, MapiPropertyType.Integer);
    var top = new ExtendedPropertyDefinition(guid, 0x8B05, MapiPropertyType.Integer);
    var items = new List<EmailMessage>();
    for (int i = 0; i != maxItems; ++i)
    {
        var m = new EmailMessage(service);
        m.Subject = "Note " + i.ToString();
        m.ItemClass = "IPM.StickyNote";
        m.Body = new MessageBody(BodyType.Text, "A test note");
        m.SetExtendedProperty(colour, 1);
        m.SetExtendedProperty(width, 200);
        m.SetExtendedProperty(height, 166);
        m.SetExtendedProperty(left, 200);
        m.SetExtendedProperty(top, 200);
        items.Add(m);
    }
    var folder = Folder.Bind(service, WellKnownFolderName.Notes, new PropertySet());
    var responses = service.CreateItems(items, folder.Id, MessageDisposition.SaveOnly, SendInvitationsMode.SendToNone);
