    public static IEnumerable<IEnumerable<int>> MakeTriangular(int[] numbers)
    {
        for (int i = 0, len = 1; i < numbers.Length; i += len, ++len)
            yield return new ArraySegment<int>(numbers, i, len);
    }
