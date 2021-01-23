        public static int[] fourthRule(int[] numberArray)
        {
            unsafe {
                int* pointer, right, left; 
                for (int i = 0, max = numberArray.Length - 1; i <= max; i++)
                {
