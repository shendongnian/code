    public class ObservationId
    {
        public int Day;
        public int PersonId;
        public ObservationId(int day, int personId)
        {
            this.Day = day;
            this.PersonId = personId;
        }
        public ObservationId(string line)
        {
            // Add code here to split data in the line to fill day and personId values
        }
    }
