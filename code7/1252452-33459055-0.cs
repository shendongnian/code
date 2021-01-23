    var nodes = list
        .GroupBy(c1 => c1.Cat1.Name)
        .Select(c1 => new Node
        {
            Name = c1.Key,
            Weight = c1.Sum(x => x.Weight),
            Children = c1
                .GroupBy(c2 => c2.Cat2.Name)
                .Select(c2 => new Node
                {
                    Name = c2.Key,
                    Weight = c2.Sum(x => x.Weight),
                    Children = c2.Select(c3 => new Node
                    {
                        Name = c3.Cat3.Name,
                        Weight = c3.Weight,
                        Children = new List<Node>()
                    }).ToList()
                }).ToList()
        }).ToList();
