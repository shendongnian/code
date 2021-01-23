    var withStatus = (IEnumerable<string> line) => line
        .Select((token, index) => new { Value = token, Index = index })        
        .Aggregate(
            new List<Data>(),
            (list, token) =>
            {
                if( token.Index % 3 == 0 )
                {
                    list.Add(new Data { System = token.Value });
                    return list;
                }
                var data = list.Last();
                if( token.Index % 3 == 1 )
                    data.Username = token.Value;
                else
                    data.Status = token.Value;
                return list;
            });
