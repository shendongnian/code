    using System.Collections.Generic;
    
    namespace SO1
    {
        public class Model
        {
            public class Result
            {
                public string list_name { get; set; }
                public string display_name { get; set; }
                public string list_name_encoded { get; set; }
                public string oldest_published_date { get; set; }
                public string newest_published_date { get; set; }
                public string updated { get; set; }
            }
    
            public class RootObject
            {
                public string status { get; set; }
                public string copyright { get; set; }
                public int num_results { get; set; }
                public List<Result> results { get; set; }
            }
        }
    }
