    public class RecordingViewModel
    {
        public List<Recording> recordings
        {
            get; set;
        }
    
        public RecordingViewModel()
        {
            recordings = new List<Recording>();
            recordings.Add(new Recording("Wolfgang Amadeus Mozart", "Andante in C for Piano", new DateTime(1761, 1, 1), "http://csimg.koopkeus.nl/srv/NL/29023839m56849/T/340x340/C/FFFFFF/url/mozart.jpg"));
            recordings.Add(new Recording("Nickleback", "Gotta be Somebody", new DateTime(2003, 8, 21), "http://images4.fanpop.com/image/photos/16500000/n-nickelback-16579001-634-634.jpg"));
        }
    
        public List<Recording> RecordingList { get { return this.recordings; } }
    }
