    public static List<T> JsonToListOfBoxes<T>(string data)
    {
        List<T> ListOfItems = new List<T>();
        string dataName = typeof(T) == typeof(Box) ? "boxes" : "envelopes";
          //if there are many types one can try in below way..
          // if (typeof(T) == typeof(Box))
          //  {
          //      dataName = "Box";
          //  }
          //  else if (typeof(T) == typeof(Envelope))
          //  {
          //      dataName = "envelopes";
          //  }
    
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
                        ListOfItems.Add((T)Activator.CreateInstance(typeof(T), productsJson[dataName][x]));
                }
        }
    
        return ListOfItems;
    }
