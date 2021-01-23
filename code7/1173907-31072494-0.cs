    public class Alert
    {
        // do not add class name to property
        public DateTime DateTime {get; set;}
        // this don't need initialization if default value is false
        public bool HasRecords {get; set;}
         public Alert()
         {
             DateTime = DateTime.Now;
         }
    }
