    public int[] SearchBytesMultiple(byte[] haystack, byte[] needle)
    {
        int index = 0;
        List<int> results = new List<int>();
        while (true)
        {
            index = SearchBytes(haystack, needle, index);
            if (index == -1)
                break;
            results.Add(index);
            index += needle.Length;
        }
        return results.ToArray();
    }
