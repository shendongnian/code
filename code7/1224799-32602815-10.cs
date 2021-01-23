    var linesUntilFirstEmpty = 
        File.ReadLines(@"c:\users\example\text.txt")
        .TakeWhile(line => !string.IsNullOrEmpty(line));
    foreach (string line in linesUntilFirstEmpty)
    {
        // Do something with line                
    }
    Console.WriteLine("No more content!");
