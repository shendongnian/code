    static bool IsEmpty(int[] S)
        {
            foreach (int x in S)
            {
                if (x != 0)
                {
                    return false; //If any element is not zero just return false now
                }
            }
            return true; //If we reach this far then the array isEmpty
        }
