    public int Collision(int oldHashKey, LinkedList<string> arr)
    {
        int newHashKey = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            newHashKey = 2 * oldHashKey - 1;
            if (arr[newHashKey] == null)
                break;
        }
        return (int)newHashKey;
    }
