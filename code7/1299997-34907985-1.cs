           public static IEnumerable<Bus> FilterBuses(string searchString, Status status)
        {
            //Setup some dummy data
            var buses = new List<Bus>()
            {
                new Bus() { BusID = 12, RegNum = "Twelve", Status = Status.ON},
                new Bus() { BusID = 13, RegNum = "Thirteen", Status = Status.OFF},
                new Bus() { BusID = 20, RegNum = "Twenty", Status = Status.OFF}
            };
            IEnumerable<Bus> filteredList = new List<Bus>();
            if (!String.IsNullOrEmpty(searchString))
            {
                filteredList = buses.Where<Bus>(b => 
                    b.RegNum.ToUpper().Contains(searchString.ToUpper()) &&
                    b.Status == status);
            }
            return filteredList.ToList();
        }
