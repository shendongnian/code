    // I replace your code with linq
    Dictionary<string, string> dictionary = 
      File.ReadAllLines("@filelocation").Select(l => l.Split(',')).ToDictionary(k =>
    k[0], v => v[1]); 
    string input = "Hello, LOL" ; 
    
    var thekey =  dictionary.Keys.FirstOrDefault(k => input.Contains(k));
   
    if (thekey != null) // Replacement was found 
    {
        input = input.Replace(thekey, dictionary[thekey]);    
    }
    Console.WriteLine(input) ;
