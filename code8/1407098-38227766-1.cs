    var values = Enum.GetNames(typeof(MyColours)).ToList();
    
    string[] colour = new string[] { "Red", "Orange", "Blue" };
    
    List<string> colourList = colours.ToList();
    
    ConatainsAllItems(values, colourList);
    
    public static bool ContainsAllItems(List<T> a, List<T> b)
    {
        return !b.Except(a).Any();
    }
