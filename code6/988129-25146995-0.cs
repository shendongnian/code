    private bool CompareObj(Visit object1, Visit object2)
    {
        foreach (var obj1PropertyInfo in object1.GetType().GetProperties())
        {
            foreach (var obj2PropertyInfo in object2.GetType().GetProperties())
            {
                if (obj1PropertyInfo.Name == obj2PropertyInfo.Name
                && !Equals(obj1PropertyInfo.GetValue(object1, null),
                obj2PropertyInfo.GetValue(object2, null)))
                {
                    return false;
                }
            }
        }
        return true;
    }
