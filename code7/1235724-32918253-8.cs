    public Car(string modelName, float topSpeed)
    {
        if (string.IsNullOrWhiteSpace(modelName)) throw new ArgumentNullException("modelName");
        _modelName = modelName;
        _topSpeed = TopSpeed;
    }
