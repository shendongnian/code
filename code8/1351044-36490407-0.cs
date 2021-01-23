    Dictionary<DateTime, List<Aulas>> query = 
        new Dictionary<DateTime, List<Aulas>>();
    _c.Aulas.ForEach(
        (a) =>
        {
            if (query.ContainsKey(a.AulaHora))
            {
                query[a.AulaHora].Add(a);
            }
            else
            {
                query.Add(a.AulaHora, new List<Aulas>() { a });
            }
        });
    return View(query);
