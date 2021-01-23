    string input = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
    var lookup = input.Split('.')
                    .Select(s => s.Split().Select(w => new { w, s }))
                    .SelectMany(x => x)
                    .ToLookup(x => x.w, x => x.s);
    foreach(var sentence  in lookup["in"])
    {
        Console.WriteLine(sentence);
    }
