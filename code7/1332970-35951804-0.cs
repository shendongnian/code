    List<string> list = new List<string>();
    list.Add("Horse");
    list.Add("Shorse");
    // we can find it with different casing
    Console.WriteLine(list.Contains("horse", StringComparer.CurrentCultureIgnoreCase)); // true
    Console.WriteLine(list.Contains("shorse", StringComparer.CurrentCultureIgnoreCase)); // true
    // but not elements that are not in the list
    Console.WriteLine(list.Contains("orse", StringComparer.CurrentCultureIgnoreCase)); // false
    // if we don’t want to ignore the case, we can also do that
    Console.WriteLine(list.Contains("Horse")); // true
    Console.WriteLine(list.Contains("Shorse")); // true
    Console.WriteLine(list.Contains("horse")); // false
    Console.WriteLine(list.Contains("shorse")); // false
    // and let’s look at a list with only Shorse to be sure…
    list.Clear();
    list.Add("Shorse");
    Console.WriteLine(list.Contains("horse")); // false
