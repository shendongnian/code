    class Schedule2 : Schedule
    {
        public String NewProperty { get; set; }
        public Schedule2(Schedule schedule)
        {
            // assign original properties here from "Schedule". e.g.
            base.RequestId = schedule.RequestId;
        }
    }
