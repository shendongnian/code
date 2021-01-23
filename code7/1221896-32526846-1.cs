       public class DataObject
        {
            public string id { get; set; }
            public string rapidViewId { get; set; }
            public string state { get; set; } 
            public string name { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string completeDate { get; set; }
            public string sequence { get; set; }
        }
    
    
        public class Program
        {
            private const string sampleStringData =
                @"[id=10151,rapidViewId=171,state=CLOSED,name=Sprint 37.1,startDate=2015-07-30T16:00:22.000+03:00,endDate=2015-08-13T16:00:00.000+03:00,completeDate=2015-08-13T14:31:34.343+03:00,sequence=10151]";
    
    
            static void Main(string[] args)
            {
                var dataObject = new DataObject();
    
                string[][] splitted;
                var sampleWithNoBrackets = sampleStringData.Substring(1,sampleStringData.Length-2);
                splitted = sampleWithNoBrackets.Split(',').Select(p => p.Split('=')).ToArray();
    
                dataObject.id           = splitted[0][1];
                dataObject.rapidViewId  = splitted[1][1];
                dataObject.state        = splitted[2][1];
                dataObject.name         = splitted[3][1];
                dataObject.startDate    = splitted[4][1];
                dataObject.endDate      = splitted[5][1];
                dataObject.completeDate = splitted[6][1];
                dataObject.sequence     = splitted[7][1];
          
                Console.ReadKey();
            }
        }
