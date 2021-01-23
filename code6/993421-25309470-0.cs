    if (Enum.IsDefined(typeof(TestEnum), 5.ToString()))
    {
        result = Enum.TryParse<TestEnum>(5.ToString(), out enumValue);
        Debug.WriteLine(result);
        if (result)
        {
            Debug.WriteLine(enumValue.ToString());
        }
    }
