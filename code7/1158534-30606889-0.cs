    public static readonly Expression<Func<MyPOCO, MyViewModel>> AsMap =
        (e) => new ImportPattern
        {    id = e.id,
             name = e.name
        }
    public static readonly Func<MyPOCO, MyViewModel>> ToMap = AsMap.Compile();
