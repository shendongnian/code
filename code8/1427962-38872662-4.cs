    class Holiday : IEquatable<Holiday>
    {
        public string Name { get; set; }
        public bool Equals(Holiday other)
        {
            return Name == other.Name;
        }
        // GetHashCode must return true whenever Equals returns true.
        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null.
            return Name?.GetHashCode() ?? 0;
        }
    }
    public class Program
    {
        public static void Main()
        {
            List<Holiday> holidayDifference = new List<Holiday>();
            List<Holiday> remoteHolidays = new List<Holiday>
            {
                new Holiday { Name = "Xmas" },
                new Holiday { Name = "Hanukkah" },
                new Holiday { Name = "Ramadan" }
            };
            List<Holiday> localHolidays = new List<Holiday>
            {
                new Holiday { Name = "Xmas" },
                new Holiday { Name = "Ramadan" }
            };
            holidayDifference = remoteHolidays
                .Except(localHolidays)
                .ToList();
            holidayDifference.ForEach(x => Console.WriteLine(x.Name));
        }
    }
