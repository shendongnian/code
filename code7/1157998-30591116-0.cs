    public static IMovable DoSomething(string typeCode)
    {
        if (typeCode == "HUM")
            return new Human();
        if (typeCode == "ANI")
            return new Animal();
        return null;
    }
