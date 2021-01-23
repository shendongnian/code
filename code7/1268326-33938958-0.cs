        public class Test 
        {  
           public string Custom1 {get; set;}    
           public string Custom2 {get; set;}
            public string EmailId
            {
                get { return Custom1; }
                set { Custom1 = value; }
            }
        }
