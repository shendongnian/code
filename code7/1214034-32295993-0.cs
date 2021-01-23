    foreach (PropertyInfo propertyInfo in potato.GetType().GetProperties())
    {
        if (propertyInfo.CanRead)
        {
              string val= propertyInfo.GetValue(potato, null).ToString();
        }
    }
