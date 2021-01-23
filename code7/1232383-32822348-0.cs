    class ABC : IEntity
    {
        int Id {get; set;} 
        string Name {get;set;}
    }
    List<T> GetData<T>(int id) where T : class, IEntity
    {
        var result = db.Set<T>().Where(x => x.Id == Id).ToList();
        return result;
    }
    ...
    var data = GetData<ABC>(10);
