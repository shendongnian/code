    private Lazy<List<string>> _classificationsCache = new Lazy<List<string>>
    (() => 
    {
        var cases = SomeServices.GetAllFOIRequests();
        return cases.SelectMany(c => c.Classifications.Classification.Select(cl => cl.Group)).Distinct().ToList();
    });
