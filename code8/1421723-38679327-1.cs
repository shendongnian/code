    var res = suggestContents.Select(
                 (x, i) => new Tuple<int, string, int>
                 (i, x, message.Split('_')
                    .Count(z => 
                    (x.ToLower().Contains(z.ToLower()))
                    ||
                     (x.ToLower().Split(@"| ".ToCharArray()).Any(w =>
                       w.Length > 0 &&
                       z.ToLower().Contains(w.ToLower())))
                    ))
                 ).GroupBy(t => t.Item3).OrderByDescending(t => t.Key).First();
