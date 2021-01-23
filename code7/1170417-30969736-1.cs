    var model = new VisualizzaFattureViewModel();
    model.Items = new Dictionary<int, List<FileInfo>>();
    foreach (var file in fattureFiles)
    {
        var year = int.Parse(fattureFiles.First().Name.Split('_').ElementAt(1));
        if (!model.Items.ContainsKey(year))
        {
            model.Items.Add(year, new List<FileInfo>());
        }
        model.Items[year].Add(file);
    }
    return View(model);
