    public static MyViewModel CreateViewModel(Test entity, MyViewModel parent = null)
    {
        return new MyViewModel(parent)
        {
           Date = entity.Date,
           IsSelected = entity.IsSelected
         };
    }
