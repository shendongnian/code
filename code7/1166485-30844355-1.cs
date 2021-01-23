    public static bool IsArraySorted(int[] numbers)
    {
        bool? ascending = null;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i - 1] != numbers[i])
            {
                bool ascending2 = numbers[i - 1] < numbers[i];
                if (ascending == null)
                {
                    ascending = ascending2;
                }
                else if (ascending.Value != ascending2)
                {
                    return false;
                }
            }
        }
        return true;
    }
