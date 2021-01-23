    // Some data object
    public class Data {
        public string Name { get; set; }
        public int Value { get; set; }
    
        public Data(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
    
    // your array
    Data[] array = new Data[]
    {
        new Data("John Smith", 123),
        new Data("Jane Smith", 456),
        new Data("Jess Smith", 789),
        new Data("Josh Smith", 012)
    }
    
    array.Any(o => o.Name.Contains("Smith"));
    // Returns true if any object's Name property contains "Smith"; otherwise, false.
    
    array.Where(o => o.Name.StartsWith("J"));
    // Returns an IEnumerable<Data> with all items in the original collection where Name starts with "J"
    
    array.First(o => o.Name.EndsWith("Smith"));
    // Returns the first Data item where the name ends with "Smith"
    
    array.SingleOrDefault(o => o.Name == "John Smith");
    // Returns the single element where the name is "John Smith". If the number of elements where the name is "John Smith" is NOT 1, this will throw an exception (SingleOrDefault is intended for selecting unique elements).
    
    array.Select(o => new { FullName = o.Name, Age = o.Value });
    // Projects your Data[] into an IEnumerable<{FullName, Value}> where {FullName, Value} is an anonymous type, Name projects to FullName and Value projects to Age.
