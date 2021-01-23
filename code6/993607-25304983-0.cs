    public static string GetString(string key)
    {
        return ResourceManager.GetString(key, ResourceCulture);
    }
    // ...
    var text = MyResourceManager.GetString("MenuOk");
