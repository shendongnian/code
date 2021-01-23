    Convert(object value, object parameter...)
    {
        if(value.GetType().Equals(typeof(myEnum)))
        {
            return Enum.GetName(typeof(myEnum), value).Replace('_', ' ');
        }
        Return value;
    }
