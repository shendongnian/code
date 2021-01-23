    public class APIClass : ILogDetails
    {
        public APIClass()
        {
        }
        public List<DomainClass> GetDomainClass()
        {
            return new List<DomainClass>()
            {
                new DomainClass(this)//Pass ILogDetails implementation
                ...
            };
        }
        public void LogDetails(DomainClass dmClass)
        {
            // Perform the required logic.
        }
    }
    public class DomainClass
    {
        private bool isTrue;
        private ILogDetails logDetails;
        //Make constructor internal to prevent client knowing this
        internal DomainClass(ILogDetails logDetails)
        {
            this.logDetails = logDetails;
        }
        public List<Expression> Expressions { get; set; }
        public bool IsTrue
        {
            get
            {
                return isTrue;
            }
            set
            {
                isTrue = value;
                logDetails.LogDetails(this);//Call the LogDetails method
            }
        }
    }
