    public static List<Transform> Tricky(this Transform here, Type ttt)
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform t in here)
        {
            Component item = t.GetComponent(ttt);
            if (item)
                result.Add(t);
        }
        return result;
    }
