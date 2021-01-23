    public static void SumDigitArrays(int[] a, int[] b, int[] result)
    {
        int length = Math.Max(a.Length, b.Length);
        for (int i = 0; i < length; i++)
        {
            int lhs = (i < a.Length) ? a[i] : 0;
            int rhs = (i < b.Length) ? b[i] : 0;
            int sum = result[i] + lhs + rhs;
            result[i] = sum % 10;
            int carry = sum / 10; 
            result[i + 1] = result[i + 1] + carry;
        }
    }
