    while (...)
    {
        FieldInfo fieldInfo = this.GetType().GetField(lines[counter], BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo != null)
        {
            Console.WriteLine(string.Format("{0}|{1}|", lines[counter], fieldInfo.GetValue(this).ToString()));
        }
    }
