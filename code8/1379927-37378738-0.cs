    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Collections.Generic;
    
    int placement = 1;
    Regex.Split("your string here", @"\s+").ToList().ForEach
    (x => { Console.WriteLine(x + "[" + placement + "]"); placement++; });
