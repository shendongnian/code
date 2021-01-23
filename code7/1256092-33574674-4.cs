    public class ProcessInformation
    {
        public string Name { get; private set; }
        public int Duration { get; private set; }
        public int ArrivalTime { get; private set; }
        public int TimeLeft { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }
        public List<int> InterruptTimes { get; private set; }
        public ProcessInformation(string name, int arrivalTime, int duration)
        {
            Name = name;
            ArrivalTime = arrivalTime;
            Duration = duration;
            TimeLeft = duration;
            InterruptTimes = new List<int>();
        }
    }
