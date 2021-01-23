    using System.Text.RegularExpressions;
    
    var inputString = "   EnemyType('1234')abcdeEnemyType('5678')xyz";
    var regex = new Regex(@"EnemyType\('\d{4}'\)");
    
    var matches = regex.Matches(inputString);
    
    foreach (Match i in matches)
    {
        Console.WriteLine(i.Value);
    }
