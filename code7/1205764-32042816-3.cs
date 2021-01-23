     var excelResult = new List<ExcelResults>();   // your code for getting results from excel;
     var dict = new Dictionary<string, Dictionary<string, int>>();
     foreach (var line in excelResult)
     {
        if (!dict.ContainsKey(line.Week))
           dict.Add(line.Week, new Dictionary<string, int>());
        if (!dict[line.Week].ContainsKey(line.Part))
            dict[line.Week].Add(line.Part, 0);
         ++dict[line.Week][line.Part];
      }
