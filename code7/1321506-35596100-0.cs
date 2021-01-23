       public class SomeClass
        {
            public string PatientName { get; set; }
            public string PatientNameScrect 
            {
                get
                {
                    return GetScrectString(PatientName);
                }
            }
    
            public string PhoneNo { get; set; }
            public string PhoneNoScrect
            {
                get
                {
                    return GetScrectString(PhoneNo);
                }
            }
            
            string GetScrectString(string ValueToReplace)
            {
                if (ValueToReplace==null)
                {
                    return ValueToReplace;
                }
                return string.Concat(Enumerable.Repeat("X", ValueToReplace.Length));
            }
        }
