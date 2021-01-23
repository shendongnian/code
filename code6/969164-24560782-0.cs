     private void ButtonAppointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments appts = new Appointments();
        
            //Identify the method that runs after the asynchronous search completes.
            appts.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(Appointments_SearchCompleted);
        
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(7);
            int max = 20;
        
            //Start the asynchronous search.
            appts.SearchAsync(start, end, max, "Appointments Test #1");
        }
        
        void Appointments_SearchCompleted(object sender, AppointmentsSearchEventArgs e)
        {
            //Do something with the results.
            MessageBox.Show(e.Results.Count().ToString());
        }
