    public List<Model.Result> BookCategory()
    {
        List<Model.Result> list = new List<Model.Result>();
        var model = JsonConvert.DeserializeObject<Model.RootObject>(TaskCategory().Result);
        
        list = model.results;
        return list;
    }
