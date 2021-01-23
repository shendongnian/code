    // Somewhere in your application/service initialization class and in some method...
    Mapper.CreateMap<ThisClass, ThisClass>();
    
    public class ThisClass
    {
        public int ThisClassID { get; set; }
        public string ThisValue { get; set;}
    
        public ThisClass()
        {
        }
    
        public ThisClass(int thisClassID)
        {
            using (MyContext dbContext = new MyContext())
            {
                Mapper.Map(dbContext.CaseNotes.Find(thisClassID), this);
            }
        }
    }
