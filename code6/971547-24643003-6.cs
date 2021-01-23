    public static void SetValues<TInn>(this IEnumerable<TInn> col, int ValueToApply)where TInn:MyClass
    {
        PropertyDescriptorCollection pdCollection = TypeDescriptor.GetProperties(typeof(TInn));
        foreach (var item in col)
        {
            foreach (PropertyDescriptor des in pdCollection)
            {
                if (des.DisplayName != "Property1" & des.DisplayName != "Property2")
                {
                    des.SetValue(item, ValueToApply);
                }
            }
        }
    }
