    string[] lines = System.IO.File.ReadAllLines(@"C:\palindromy.txt");
    var palindromes = lines.Where(x => x == new string(x.ToCharArray()
                           .Reverse()
                           .ToArray()));
    var shortest = palindromes.Aggregate((a, b) => a.Length < b.Length ? a : b);
    var longest = palindromes.Aggregate((a, b) => a.Length > b.Length ? a : b);
	Console.WriteLine("The shortest palindrome is {0}.", shortest);
	Console.WriteLine("The longest palindrome is {0}.", longest);
