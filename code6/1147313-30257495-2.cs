    public class MergedInstance : IPerson
    {
        public IPerson TalkIPerson { get; set; }
        public IPerson LunchIPerson { get; set; }
    
        public void Talk() 
        {
           TalkIPerson.Talk();
        }
    
        public Lunch() {
           LunchIPerson.Lunch();
        }
    }
