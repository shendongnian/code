    public class Job
    {
        public JobType Type { get; set; }
    
        public Job (JobType jobType)
        {
            Type = jobType;
        }
    
        // Type1Record and Type2Record both inherit from RecordBase
        public IEnumerable<RecordBase> GetRecords()
        {
           if (Type == JobType.Type1)
           {
               return GetType1Records();
           }
           if (Type == JobType.Type2)
           {
                return GetType2Records();
           }
           return null;
        }
    }
