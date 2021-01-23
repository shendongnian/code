     List<string> values = new List<string>();
     values.Add("/ a /b/111.txt");
     values.Add("/ a / b / c / 222.txt");
     values.Add("a / b / 333.txt");
     values.Add("a / b / c / d / 444.txt");            
     var sortedList = values.OrderBy(p => p.Count(c => c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar));
