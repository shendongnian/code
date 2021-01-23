    public class Company
        {
            public Dictionary<string, string> companyObject = 
                new Dictionary<string, string>();
            public Dictionary<string, string> 
                Add(string twentyEight, string three, string six,
                string twentOne, string fourteen, string sixteen)
            {
                companyObject.Add("28", twentyEight);
                companyObject.Add("3", three);
                companyObject.Add("6", six);
                companyObject.Add("21", twentOne);
                companyObject.Add("14", fourteen);
                companyObject.Add("16", sixteen);
                return companyObject;
            }
        }
