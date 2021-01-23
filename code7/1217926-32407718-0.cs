    public static bool AllPublicPropertiesEqual(object AObj, object BObj, params string[] ignore) 
    {
        if (AObj != null && BObj != null)
        {
            Type type = AObj.GetType();
            if (BObj.GetType() != type)
                throw new Exception("Objects should be of the same type");
            ....
        }
        ....
    }
