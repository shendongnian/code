        class ElementWithGroup
        {
            public string Element { get; set; }
            public int Index { get; set; }
            public int Group { get; set; }
        }
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "A",
                "A",
                "B",
                "A",
                "C",
                "B",
                "B",
                "C"
            };
            var helpList = list
                .Select((e, i) => new ElementWithGroup { Element = e, Index = i, Group = 0 })
                .ToList();
            var result = helpList
                .GroupBy(e => {
                    var previous = e.Index == 0 ? null : helpList.ElementAt(e.Index - 1);
                    if (previous != null)
                    {
                        e.Group = previous.Element == e.Element ? previous.Group : previous.Group + 1;
                    }
                    return e.Group;
                });
        }
