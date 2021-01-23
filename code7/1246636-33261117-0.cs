    var theModel = models.First(); // select a model
    
    foreach (var interm in intermediates.Where(x => x.Parent == theModel.Node))
    {
        foreach (var res in results.Where(x => x.Parent == interm.Node))
        {
            res.Name = theModel.Name;
        }
    }
