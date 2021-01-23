    public static void MyCall(List<Type> aListOfClasses)
    {
        foreach (var item in aListOfClasses)
        {
            var typeInfo = item; // no need for typeof again
        }
    }
