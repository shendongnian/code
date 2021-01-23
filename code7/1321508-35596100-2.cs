       public class SomeClass
        {
            public string PatientName { get; set; }
            public string PatientNameSecret 
            {
                get
                {
                    return GetSecretString(PatientName);
                }
            }
    
            public string PhoneNo { get; set; }
            public string PhoneNoSecret
            {
                get
                {
                    return GetSecretString(PhoneNo);
                }
            }
            
            string GetSecretString(string ValueToReplace)
            {
                if (ValueToReplace==null)
                {
                    return ValueToReplace;
                }
                return string.Concat(Enumerable.Repeat("X", ValueToReplace.Length));
            }
        }
