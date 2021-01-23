    public static class Arrays
    {
        public static bool AreAllTheSameLength(params Array[] arrays)
        {
            return arrays.All(a => a.Length == arrays[0].Length);
        }
    }
