    public Car(string modelName, int topSpeed)
    {
        if (string.IsNullOrWhiteSpace(modelName)) throw new ArgumentNullException("modelName");
        _modelName = modelName;
        _currentSpeed = CurrentSpeed;
        _topSpeed = TopSpeed;
    }
