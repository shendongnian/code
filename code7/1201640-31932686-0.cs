    class Aggregate
    {
        public AlertData AlertData {get;set;}
        public SoundRequestData SoundRequestData { get; set; }
        public int Id { get { return AlertData == null ? SoundRequestData.Id : AlertData.Id; } } 
    }
