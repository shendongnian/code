    Regex testRegex = new Regex(@"\(([-|+]?\d+\|[-|+]?\d+?)\)");
    Stopwatch stopwatch = Stopwatch.StartNew();
    var matches = testRegex.Matches(input);
    var matchesCount = matches.Count;
    stopwatch.Stop();
    Console.WriteLine("Time Elapsed :\t{0}\nInputLength :\t{1}\nMatches Count :\t{2}", stopwatch.Elapsed, input.Length, matchesCount);
