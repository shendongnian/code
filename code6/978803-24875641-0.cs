    while (...)
    {
        FieldInfo fieldInfo = this.GetType().GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo != null)
        {
            Console.WriteLine(string.Format("{0}|{1}|", propertyName, fieldInfo.GetValue(this).ToString()));
        }
    }
