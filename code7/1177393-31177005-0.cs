        public void Display(int[] resetCount, int[] count, bool[] flags)
        {
            for (int i = 0; i < resetCount.Count(); i++)
            {
                resetCount[i] = this.Calculate(resetCount[i], count[i], flags[i]);
            }
        }
        public int Calculate(int resetCount, int count, bool flag)
        {
            if (flag)
            {
                resetCount = count;
            }
            else
            {
                resetCount += count;
            }
            return resetCount;
        }
