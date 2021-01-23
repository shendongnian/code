    var query = Fisks
        .Where(f => f.Havn.Id == 1)
        .OrderByDescending(f => f.Date)
        .ThenBy(f => f.Arter.Name)
        .ThenBy(f => f.Sort);
    var list = new List<Fisk>();
    foreach (Fisk fisk in query) {
        if (list.Count == 0) {
            list.Add(fisk);
        } else {
            Fisk last = list[list.Count - 1];
            if (fisk.Sort != last.Sort || fisk.Arter.Name != last.Arter.Name) {
                list.Add(fisk);
            }
        }
    }
