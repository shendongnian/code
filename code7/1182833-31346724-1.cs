    public static List<T> JsonToListOfBoxes<T>(string data, string dataName)
    {
        List<T> ListOfItems = new List<T>();
        if (!string.IsNullOrEmpty(data))
        {
            JObject productsJson = JObject.Parse(data);
            JToken jtkProduct;
            jtkProduct = productsJson[dataName];
            if (jtkProduct != null)
                if (jtkProduct.HasValues)
                {
                    int childrenCount = productsJson[dataName].Count();
                    for (int x = 0; x < childrenCount; x++)
                        ListOfItems.Add((T)Activator.CreateInstance(typeof(T), productsJson[dataName][x]);
                }
        }
        return ListOfItems;
    }
