    var withoutStatus = (IEnumerable<string> line) => line
        .Select((token, index) => new { Value = token, Index = index })
        .Aggregate(new List<Data>(),
            (list, token) => 
            {
                if( token.Index % 2 == 0)
                    list.Add(new Data { System = token.Value });
                else
                    list.Last().Username = token.Value;
                return list;
            });
