    // using System.Linq;
    // Look for a match...
    var result = cases
        .Where(c => c.Item3(subArea, c.Item1))
        .FirstOrDefault();
        
    // Return the match or the default.
    return result == null ? "ABCXYZ123" : result.Item2;
