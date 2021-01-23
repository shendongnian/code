    var files = dinfo.GetFiles("*.txt");
    System.Collections.Generic.IEnumerable<String> _eValA, _eValB;
    // Should really assert that files.Count == 2
    _evalA = File.ReadLines(files.First().Name);
    _eValB = File.ReadLines(files.Last().Name);
    IEnumerable<String> union = _eValA.Union(_eValB);
