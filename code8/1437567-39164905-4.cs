        List<YourType> collection1 = new List<YourType>();
        List<YourType> collection2 = new List<YourType>();
        foreach(var item in baseCollection)
        {
            if(filterCollection.Contains(item.Property))
            {
                collection1.Add(item);
            }
            else
            {
                collection2.Add(item);
            }
        }
