    public Result<Size> ResultForSize()
    {
        return CreateResult(() => service.GetBySize());
    }
    public Result<Color> ResultForColor()
    {
        return CreateResult(() => service.GetByColor());
    }
    public Result<Model> ResultForModel(int id)
    {
        return CreateResult(() => service.GetByModdel());
    }
