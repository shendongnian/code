    String str = "12 hours 14 mins";
    String digitsOnly = Regex.Match(str, @"\d+").Value;
    if (digitsOnly.Length != 4) throw new ArgumentException();
    int hours = int.Parse(digitsOnly.Substring(0, 2));
    int minutes = int.Parse(digitsOnly.Substring(2, 2));
    Console.WriteLine(hours * 60 + minutes);
