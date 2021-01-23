    public void ChangeList<T>(ref List<T> source, T value)
    {
        //Actions
        source = new List<T>; // or initialize using API/DB call
        source.Add(value);
        //Actions
    }
