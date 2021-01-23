    //using System.Linq;
    string input1 = "abc  dfg";
    string input2 = "尾え　れ";
    if (input1.Any(char.IsWhiteSpace))
    {
    
       Console.WriteLine(new string(input1.Select(x=> char.IsWhiteSpace(x) ? '_' : x).ToArray()));
    }
    Console.WriteLine("------------------");
    if (input2.Any(char.IsWhiteSpace))
    {
    
         Console.WriteLine(new string(input2.Select(x => char.IsWhiteSpace(x) ? '_' : x).ToArray()));
    }
