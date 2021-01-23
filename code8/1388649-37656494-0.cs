        static void CreateAndSeedDatabase()
        {
            Context context = new Context();
            ClinicianAvailability cAvail = new ClinicianAvailability() { };
            SurgicalBooking sBooking = new SurgicalBooking() { IsAdhoc = true, ClinicianAvailability = cAvail };
            context.SurgicalBookings.Add(sBooking);
            context.SaveChanges();
        }
        static void DeleteUpdateInsert()
        {
            Context context = new Context();
            ClinicianAvailability cAvail = context.ClinicianAvailabilitys.Find(1);
            SurgicalBooking sBooking = context.SurgicalBookings.Find(1);
            sBooking.IsAdhoc = false;
            sBooking.ClinicianAvailability = null;
            TheatreBooking tBooking = new TheatreBooking(){SurgicalBooking = sBooking};
            context.TheatreBookings.Add(tBooking);
            context.ClinicianAvailabilitys.Remove(cAvail);
            context.SaveChanges();
        }
