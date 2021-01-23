    String input = @"<Sync Start=25199><P Class=ENCC>
    foo
    <Sync Start=26522><P Class=ENCC>
    bar
    <Sync Start=27863><P Class=ENCC>
    stack
    <Sync Start=30087><P Class=ENCC>
    overflow";
    Regex rgx = new Regex(@"(?m)<Sync Start=(.*?)><P Class=(.*?)>\n(\w+)");
    foreach (Match m in rgx.Matches(input))
    {
    Console.WriteLine(m.Groups[1].Value);
    Console.WriteLine(m.Groups[2].Value);
    Console.WriteLine(m.Groups[3].Value);
     }
