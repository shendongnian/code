    public static List<T> ListOfValueFrequencyToList(IEnumerable<ValueFrequency<T>> valueFrequencyList)
    {
        bool isCloneable = typeof(ICloneable).IsAssignableFrom(typeof(T));
        List<T> result = new List<T>();
        foreach (ValueFrequency<T> vf in valueFrequencyList)
        {
            for (int i = 0; i < vf.Frequency; i++)
            {
                if (isCloneable)
                    result.Add((T)((ICloneable)vf.Value).Clone());
                else
                    result.Add(vf.Value);
            }
        }
        return result;
    }
