    [ImplementPropertyChanged]
    public class Person 
    {        
        public string GivenNames { get; set; }
        public string FamilyName { get; set; }
    
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", GivenNames, FamilyName);
            }
        }
    }
