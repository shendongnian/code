    var lines = File.ReadAllLines("samples.txt"); 
    Console.WriteLine(JsonConvert.DeserializeObject<IdItem>(lines[0]).ID);
    Console.WriteLine(JsonConvert.DeserializeObject<Context>(lines[1]).context.First().First().ID);
    Console.WriteLine(JsonConvert.DeserializeObject<Details>(lines[2]).date);
    Console.WriteLine(JsonConvert.DeserializeObject<TraceValue>(lines[3]).context.context.First().First().ID);
    Console.WriteLine(JsonConvert.DeserializeObject<Trace>(lines[4]).trace.context.context.First().First().ID);
    Console.WriteLine(JsonConvert.DeserializeObject<List<Trace>>(lines[5]).First().trace.context.context.First().First().ID);
