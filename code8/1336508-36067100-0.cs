     Dictionary<int, List<Service>> Dic = new Dictionary<int, List<Service>>();
        foreach (var id in facilities)
        {
            Dic.Add(id,  _context.Services.Where(x => x.Facilities.Any(y => y.Id == id)).ToList());
        }
