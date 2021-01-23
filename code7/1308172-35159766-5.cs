    using System.Linq;
    var testValues = new List<string> { ... }; // A huge collection of strings
    var testDict = testValue.ToDictionary(elem => elem, elem => true);
    
    var needle = Test.OptionOne.ToString();
    if (testDict.ContainsKey(needle))
    {
       // do something
    }
