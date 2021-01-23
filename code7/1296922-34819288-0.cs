    public class PairHistoryItem
    {
    	[JsonProperty]
        public List<Person> People { get; private set; }
        public DateTime PairDate { get; }
    
        public PairHistoryItem(Person person1, Person person2, DateTime pairDate)
        {
            People = new List<Person> {person1, person2};
            PairDate = pairDate;
        }
    }
