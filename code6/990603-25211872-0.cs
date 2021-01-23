    public string FromDtoProperty<T>(T source)
    {
        if (!typeof(T).IsEnum) 
        {
            throw new ArgumentException("T must be an enumerated type");
        }
        return ((Enum)(object)source).ToDescription();
    }
