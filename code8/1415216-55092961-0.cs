    public static Int32[] ArrayRightRotation(Int32[] A, Int32 k)
        {
            if (A == null)
            {
                return A;
            }
            if (!A.Any())
            {
                return A;
            }
            if (k % A.Length == 0)
            {
                return A;
            }
            if (A.Length == 1)
            {
                return A;
            }
            if (A.Distinct().Count() == 1)
            {
                return A;
            }
            for (var i = 0; i < k; i++)
            {
                var intermediateArray = new List<Int32> {A.Last()};
                intermediateArray.AddRange(A.Take(A.Length - 1).ToList());
                A = intermediateArray.ToArray();
            }
            return A;
        }
