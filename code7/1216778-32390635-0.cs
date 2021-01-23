            PropertySet YourProperyset = new PropertySet(BasePropertySet.FirstClassProperties);
            var extendendProperty = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Address, "organizer",MapiPropertyType.String);
            YourProperyset.Add(extendendProperty);
            var folderId = new FolderId(WellKnownFolderName.Calendar, new Mailbox(userName));
            var calendar = CalendarFolder.Bind(service, folderId);
            var calendarView = new CalendarView(start, stop);
            calendarView.PropertySet = YourProperyset;
            return calendar.FindAppointments(calendarView).ToList();
