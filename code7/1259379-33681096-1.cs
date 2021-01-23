        public class Person
        {
            public string Name { get; set; }
            public string Postcode { get; set; }
            public string Town { get; set; }
            public string Country { get; set; }
            public string TwitterUrl { get; set; }
            public string FacebookUrl { get; set; }
            public string GooglePlusUrl { get; set; }
            
            public Person(string name, string postcode, string town, string country, string twitterurl, string facebookurl, string googleplusurl)
            {
                Name = name;
                Postcode = postcode;
                Town = town;
                Country = country;
                TwitterUrl = twitterurl;
                FacebookUrl = facebookurl;
                GooglePlusUrl = googleplusurl;
            }
        }
