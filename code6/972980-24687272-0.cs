    List<int> values = new List<int> { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 };
   
    var series = String.Concat(values)
                       .Split(new[] { '0' }, StringSplitOptions.RemoveEmptyEntries)
                       .Where(s => s.Length >= 6);
