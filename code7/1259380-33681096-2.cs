        public class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }
            public SocialMedia SocialMedia { get; set; }
            
            public Person(string name, Address address, SocialMedia socialmedia)
            {
                Name = name;
                Address = address;
                SocialMedia = socialmedia;
            }
        }
        
        public class Address
        {
            public string Postcode { get; set; }
            public string Town { get; set; }
            public string Country { get; set; }
        }
        
        public class SocialMedia
        {
            public string TwitterUrl { get; set; }
            public string FacebookUrl { get; set; }
            public string GooglePlusUrl { get; set; }
        }
