    public class Publication
    {
        public string Name { get; set; }
        public string DropdownText { get; set; }
        public string DropdownValue { get; set; }
        public string BaseURL { get; set; }
        public static Publication MotocrossWeekly = new Publication
        {
            Name = "Motocross Weekly",
            DropdownText = "Motocross Weekly",
            DropdownValue = "18",
        };
        public static Publication ExtremeWelding = new Publication
        {
            Name = "Extreme Welding",
            DropdownText = "Extreme Welding",
            DropdownValue = "6",
        };
        public static Publication HackersGuide = new Publication
        {
            Name = "Hacker's Guide to Security",
            DropdownText = "Hacker's Guide",
            DropdownValue = "36",
        };
        public static IList<Publication> Publications
        {
            get
            {
                return typeof(Publication).GetFields(BindingFlags.Static | BindingFlags.Public)
                    .Select(f => (Publication)f.GetValue(null))
                    .ToList();
            }
        }
    }
