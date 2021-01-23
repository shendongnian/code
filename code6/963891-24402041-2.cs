    string sentence = "\"Joe wants to thank you! comma, ellipsis...exclamation! period.\"";	
    string pattern = @"(\.\.\.)|([ ""\.,\\!])";
    IEnumerable<string> words = Regex.Split(sentence, pattern)
                                     .Where (x => !String.IsNullOrWhiteSpace(x));
    foreach (var word in words) { Console.WriteLine(word); }
