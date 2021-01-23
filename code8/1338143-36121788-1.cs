    var list = new List<Tuple<Events, History[]>;
    foreach (var teamInEvent in ListEvents)
    {
        var item = Tuple.Create(teamInEvent, GetHistory(teamInEvent).ToArray());
        list.Add(item);
    }
 
