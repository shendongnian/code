        private async void btnAddStop_Click(object sender, RoutedEventArgs e)
        {
            // check if the stop is already added for the bus
            List<Buses> buses = new List<Buses>();
            buses = LocalDatabase.GetStopListByBusNumberAndStopName(Id.Text, StopName.Text);
            if (buses.ToArray().Length > 0)
            {
                await new MessageDialog("Cannot add this stop because the stop is already added for the bus!").ShowAsync();
            }
            else
            {
                Buses b = new Buses();
                b.number = Id.Text;
                b.StopName = StopName.Text;
                b.Timetable = Timetable.Text;
                // add the stop to db
                LocalDatabase.InsertStopToDatabase(b);
                await new MessageDialog("The stop is added successfully!").ShowAsync();
            }
        }
        
        // get the buses by bus number
        public static List<Buses> GetStopListByBusNumber(string busNumber)
        {
            List<Buses> results = new List<Buses>();
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                results = conn.Query<Buses>("SELECT * FROM Buses WHERE number = ?", busNumber);
            }
            return results;
        }
        // get the buses by bus number and stop name
        public static List<Buses> GetStopListByBusNumberAndStopName(string busNumber, string stopName)
        {
            List<Buses> results = new List<Buses>();
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                results = conn.Query<Buses>("SELECT * FROM Buses WHERE number = ? AND StopName = ?", busNumber, stopName);
            }
            return results;
        }
