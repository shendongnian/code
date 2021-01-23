    public Car(string modelName, float topSpeed)
    {
        if (string.IsNullOrWhiteSpace(modelName)) throw new ArgumentNullException("modelName");
        ModelName = modelName;
        TopSpeed = topSpeed;
    }
