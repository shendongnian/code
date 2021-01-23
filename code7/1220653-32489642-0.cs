    public static T FindObject<T> (this GameObject gameObject, string objectName)
    {
       var type = typeof(T);
       var ret = gameObject.GetComponentsInChildren(type).Where(w => w.name == objectName).First().gameObject;
       return (T)Convert.ChangeType(ret, type);
    }
