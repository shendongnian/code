       public int MissingInteger(int[] A)
        {
            A = A.Where(a => a > 0).Distinct().OrderBy(c => c).ToArray();
            if (A.Length== 0)
            {
                return 1;
            }
            for (int i = 0; i < A.Length; i++)
            {
                //Console.WriteLine(i + "=>" + A[i]);
                if (i + 1 != A[i])
                {
                    return i + 1;
                }
            }
            return A.Max() + 1;
        }
