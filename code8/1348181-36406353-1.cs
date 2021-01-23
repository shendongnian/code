        public static int[]  MultiplyDigitArrays(int[] lhs, int[] rhs)
        {
            int length1 = Math.Max(lhs.Length, rhs.Length);
            var result = new int[length1* length1];
            for (int i = 0; i < length1; i++)
            {
                int[] PartialProduct = new int[length1 * length1];
                int length2 = Math.Min(lhs.Length, rhs.Length);
                for (int j = 0; j < length2; j++)
                {
                    int multiplicand = (lhs.Length < rhs.Length) ? rhs[i] : lhs[i];
                    int multiplier = (lhs.Length < rhs.Length) ? lhs[j] : rhs[j];
                    int product = PartialProduct[i + j] + multiplicand * multiplier;
                    PartialProduct[i + j] = product % 10;
                    int carry = product / 10;
                    PartialProduct[i + j + 1] = PartialProduct[i + j + 1] + carry;
                }
                result = SumDigitArrays(PartialProduct, result);
            }
            return result;
        }
        public static int[] SumDigitArrays(int[] a, int[] b)
        {
            int length = Math.Max(a.Length, b.Length);
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int lhs = (i < a.Length) ? a[i] : 0;
                int rhs = (i < b.Length) ? b[i] : 0;
                int sum = result[i] + lhs + rhs;
                result[i] = sum % 10;
                int carry = sum / 10;
                if (i + 1 < result.Length)
                {
                    result[i + 1] = result[i + 1] + carry;
                }
            }
            return result;
        }
