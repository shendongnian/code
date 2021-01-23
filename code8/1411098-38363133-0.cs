    public class NumberLink {
       int Value { get; set; }
       int Link { get; set; }
    }
    
    List<NumberLink> numberLinks =
       new List<int> {
          0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
       }
       .Select(i => new NumberLink { Value = i })
       .ToList();
    
    numberLinks.First(nl => nl.Value == 0).Link = 5;
    numberLinks.First(nl => nl.Value == 1).Link = 6
