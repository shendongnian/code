     public AppointmentData[] RetrieveAppointments(bool persistChange)
        {
            var appointmentData = new List<AppointmentData>();
            
            
            using (var context = new FmServiceContext(_service))
            {
                //First we get all relevant appointments
                var appointments = (from app in context.AppointmentSet
                                    where app.StateCode != 0
                                    select new { app});
                                  
                foreach (var appointment in appointments)
                {
                   //we loop all the returned attendees of the appointments
                    var attendees = new List<Attendee>();
                    foreach (var attendee in appointment.app.RequiredAttendees)
                    {
                        if (attendee.PartyId != null)
                        {
                            //if an attendee is an account
                            if (attendee.PartyId.LogicalName == "account")
                            {
                                var account = (from acc in context.AccountSet
                                    where acc.AccountId == attendee.PartyId.Id
                                    select new {acc});
                            }
                             //add the attendee
                              {
                                attendees.Add(new Attendee
                                {
                                    // get additional metadata of the attendee
                                });
                            }
                          appointmentData.Add(new AppointmentData
                    {
                        Attendees = attendees,
                        // get additional metadata of the appointment
                    });
                        }
                    }
                 }
                 return appointmentData.ToArray();
            }
        }
    }
