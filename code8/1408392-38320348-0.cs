    Appointment newAppointment = new Appointment(service);
    newAppointment.Subject = "Test Subject";        
    newAppointment.Start = new DateTime(2016, 08, 27, 17, 00, 0);
    newAppointment.StartTimeZone = TimeZoneInfo.Local;
    newAppointment.EndTimeZone = TimeZoneInfo.Local;
    newAppointment.End = newAppointment.Start.AddMinutes(30);
    newAppointment.Save();
    newAppointment.Body = new MessageBody(Microsoft.Exchange.WebServices.Data.BodyType.Text, "test");
    newAppointment.RequiredAttendees.Add("attendee@domain.com");
    newAppointment.Update(ConflictResolutionMode.AlwaysOverwrite ,SendInvitationsOrCancellationsMode.SendOnlyToAll);
    ExtendedPropertyDefinition CleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x23, MapiPropertyType.Binary);
    PropertySet psPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
    psPropSet.Add(CleanGlobalObjectId);
    newAppointment.Load(psPropSet);
    object CalIdVal = null;
    newAppointment.TryGetProperty(CleanGlobalObjectId, out CalIdVal);
    Folder AtndCalendar = Folder.Bind(service, new FolderId(WellKnownFolderName.Calendar,"attendee@domain.com"));
    SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(CleanGlobalObjectId, Convert.ToBase64String((Byte[])CalIdVal));
    ItemView ivItemView = new ItemView(1);
    FindItemsResults<Item> fiResults = AtndCalendar.FindItems(sfSearchFilter, ivItemView);
    if (fiResults.Items.Count > 0) {
        //do whatever
    }
