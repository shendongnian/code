    public MyViewModel GetViewModel(...)
    {
        var model = ...;
        model.IsPrintable = this.IsPrintable(items, pages);
        return model;
    }
