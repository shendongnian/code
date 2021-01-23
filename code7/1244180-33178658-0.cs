        public class Person
        {
            public int StopNumber { get; set; }
            public string Notes { get; set; }
            public DateTime? thing { get; set; }
            public bool IsMale { get; set; }
        }
        public List<Person> Join(List<Male> males, List<Female> females)
        {
            return
                males.Select(
                    n => new Person() {
                        IsMale = true, 
                        Notes = n.Notes, 
                        StopNumber = n.RunNumber, 
                        thing = n.thing} 
                ).Concat(
                         females.Select(
                             m => new Person() {
                                    IsMale = false,
                                    Notes = m.Notes, 
                                    StopNumber = m.StopNumber, 
                                    thing = m.thing})
                    ).ToList();
        }
