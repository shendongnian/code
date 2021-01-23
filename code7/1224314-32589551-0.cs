    public dynamic SampleToDynamic(Sample sample)
    {
        IDictionary<string, object> expando = new ExpandoObject();
        expando["Name"] = sample.Name;
        for (int i = 0; i < sample.RawReadings.Count; i++)
        {
            expando["RawRead" + (i + 1)] = sample.RawReadings[i];
        }
        return expando;
    }
