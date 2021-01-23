    public void Deserialize (string jsonString)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        dynamic myData = serializer.Deserialize<object>(jsonString);
        if (myData ["version"] == 1) {
            ...
        }
    }
