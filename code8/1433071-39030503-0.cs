    public class PersonRecord
    {
        public string Name { get; set; }
        public string AgeText { get; set; }
        public int Age {get;set;} // ideally you wanna use integer to store person's age
    }
    
    public IEnumerable<string> GetAgeValue(string searchName)
    {
        var records = new List<PersonRecord>()
        {
           new PersonRecord {Name="David", AgeText="22 years old", Age = 22 },
           new PersonRecord {Name="Sarah", AgeText="23 years old", Age = 23 },
           new PersonRecord {Name="Jane", AgeText="24 years old", Age = 24 },
        };
        // assume it follows the strict format, "[age] years old", so we will get the age value based on the first occurrence of the white space
        var result = records.Where(x => x.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)).Select(x => x.AgeText.Substring(0, x.AgeText.IndexOf(" ") + 1));
        // alternatively just do a query on the age directly, much easier
        // var result = records.Where(x => x.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Age.ToString()); 
        return result;
    }
