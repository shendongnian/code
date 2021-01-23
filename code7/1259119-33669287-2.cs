    Regex re = new Regex("^[a-z].*[0-9]{2}$", RegexOptions.IgnoreCase);
    Console.WriteLine(re.IsMatch("Apple02")); // true
    Console.WriteLine(re.IsMatch("Arrow")); // false
    Console.WriteLine(re.IsMatch("45Alty12")); // false
    Console.WriteLine(re.IsMatch("Basci98")); // true
