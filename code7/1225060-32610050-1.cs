    using System.Linq;
    var strings = new[] { "and", "nand", "not", "or", "nor", "xor" };
    foreach (var s in strings.Repeat(3).SelectMany(s => s)) 
    {
        Debug.WriteLine(s);
    }
