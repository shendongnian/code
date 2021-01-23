            List<Entry> entries = new List<Entry>(); //This is your Input
            entries.Add(new Entry()
            {
                Name = "Betty",
                AppointmentType = "New",
                DateTime = DateTime.Now.AddDays(-1)
            });
            entries.Add(new Entry()
            {
                Name = "Sally",
                AppointmentType = "New",
                DateTime = DateTime.Now
            });
            entries.Add(new Entry()
            {
                Name = "Amy",
                AppointmentType = "New",
                DateTime = DateTime.Now.AddHours(-15)
            });
