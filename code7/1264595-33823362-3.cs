    string input = "5#9#6#4#6#8#0#7#1#5";
    var nums = input.Split('#').Select(s => Int32.Parse(s));
    var res = Enumerable.Range(0, nums.Count())
                        .Select(n => nums.Skip(Enumerable.Range(0, n).Sum()).Take(n));
                        .Where(x => x.Any());  // here you have IEnumerable<int> for every row 
                        .Select(arr => arr.Max());
            
              
