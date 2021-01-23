    string text = "hello dear";
    string longestRun = new string(text.Select((c, index) => text.Substring(index).TakeWhile(e => e == c))
                                       .OrderByDescending(e => e.Count())
                                       .First().ToArray());
    Console.WriteLine(longestRun); // ll
