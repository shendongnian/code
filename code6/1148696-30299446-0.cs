    foreach (var property in this.GetType().GetProperties())
    {
        var propVal = property.GetValue(this) as List<Object>;
        if (propVal != null)
        {
            propVal.Clear();
        }
    }
