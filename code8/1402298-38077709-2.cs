    public class GradeStatistics
    {
        public GradeBook aveg {get; set;}
        // constructor
        public GradeStatistics()
        {
            // from now on you can use it also in methods
            aveg = new GradeBook();
    
        }
        public void clearForeignList()
        {
             this.aveg.GradesList.Clear();
        }
    }
