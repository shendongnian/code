    string strUser;
    string strSubCheck;
    Console.WriteLine("Please type in a word:");
    strUser = Console.ReadLine();
    strSubCheck = strUser.Substring(0, 1);
    var vowelCheck = new[] { "a", "e", "i", "o", "u" };
    if (vowelCheck.Contains(strSubCheck.ToLower()))
    {
        Console.WriteLine("\nThe first letter is a vowel");
    }
    else Console.WriteLine("\nThe first letter is a consonant");
