    public object GetSerializationObjectForKid(Kid kid)
    {
        return new 
        {
            age = kid.age,
            name = kid.name,
            toy_1 = toys.ElementAtOrDefault(0), 
            toy_2 = toys.ElementAtOrDefault(1),
            toy_3 = toys.ElementAtOrDefault(2)
        }
    }
