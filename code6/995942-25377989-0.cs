    public void SaveOrUpdate<T>(T model)
    {
    if(model is TimeStampEntity) 
    {
    ((TimeStampEntity)model).TimeStamp = DateTime.UtcNow;
    }
    repository.SaveOrUpdate(model)
    }
