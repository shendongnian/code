    private IEnumerable<SomeType> DoStuff(IEnumerable<OtherType> e)
    {
        foreach (var elem in e)
        {
            yield return new SomeType
            {
                SomeProperty = elem.OtherProperty
            };
        }
    }
