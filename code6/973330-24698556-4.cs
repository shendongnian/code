    public static void StringToObject(string buffer, out Comarea comarea)
    {
        comarea.status = buffer.Substring(0, 1);
        comarea.operationName = buffer.Substring(1, 5);
    }
