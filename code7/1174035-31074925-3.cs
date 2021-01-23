    var indexesToChoose = new List<int> {1, 2};
    var cat = solutions
                .Descendants("Solution")
                .Select(x => new
                {
                    ID = (string)x.Element("ID"),
                    Properties = x.Elements("Property")
                        .Select((p, i) => new
                        {
                            Name = (string)p.Element("Name"),
                            Value = (string)p.Element("Value"),
                            idx = i
                        })
                        .Where(y => indexesToChoose.Contains(y.idx))
                        //.OrderBy(z => indexesToChoose.FindIndex(p => p == z.idx))
                        .ToList()
                });
