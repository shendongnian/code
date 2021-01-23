    public class Flow
    {
        public Action actionField {get; set; }
    
        public class Flow()
        {
            actionField = new Action();  // otherwise it shows up as null
        }
    }
