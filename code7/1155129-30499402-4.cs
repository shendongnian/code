    class Record
    {
        public int ClientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Record(int clientId, DateTime startDateTime, DateTime endDateTime)
        {
            ClientId = clientId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
