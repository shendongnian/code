    class CallInformation {
        public DateTime CallStart { get; private set; }
        public Boolean IsOutGoing {get; private set; }
        public String CSRName {get; private set; }
        public int InComingCount { get; set; }
        public int OutgoingCount { get; set; }
        public CallInformation(String[] parts) {
            IsOutGoing = parts[4] == "O";
            CallStart = DateTime.Parse(parts[0]);
            CSRName = parts[12];
        }
        //... Continue with the important properties
    }
