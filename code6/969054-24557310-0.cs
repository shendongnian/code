    var calls = callLogs.GroupBy(x => x.Number)
                        .Select(x => new {
                            Number = x.Key,
                            Incoming = x.Where(c => c.Incoming).ToList(),
                            Outgoing = x.Where(c => !c.Incoming).ToList()
                        });
