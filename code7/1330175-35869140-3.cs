    Dictionary<int, string> words = new Dictionary<int, string>()
    {
        {0, "Israel"},
        {1, "Mark"},
        {2, "Foo"},
        {3, "Bar"} // add more if you want
    };
    Random Rnd = new Random();
    int randomNumber = Rnd.Next(0, words.Count); // Attention! Dict, list etc. use .Count not .Length!
    int points = 0;
    Console.WriteLine(randomNumber);  
  
    Console.WriteLine("Please enter your name");
    string name = Console.ReadLine();    
    
    string word = "";
    if(!words.TryGetValue(randomNumber, out word)) return; // whoops index not found in dictionary!
    if(word.Equals(name))
    {
        points += 5;
        Console.WriteLine("Marks: {0}\nYou won!!!!", points);
    }
    else
        Console.WriteLine("Incorrect");
    
