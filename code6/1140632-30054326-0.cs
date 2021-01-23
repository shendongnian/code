    public object GetSerializationObjectForKid(Kid kid)
    {
        return new 
        {
            age = kid.age,
            name = kid.name,
            toy_1 = toys.Count >= 1 ? toys[0] : null, 
            toy_2 = toys.Count >= 2 ? toys[1] : null,
            toy_3 = toys.Count >= 3 ? toys[2] : null
        }
    }
