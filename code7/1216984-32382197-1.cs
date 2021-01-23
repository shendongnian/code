    class unSortedArray
    {
        public int size;
        public int[] array;
    
        public unSortedArray()
        {
           array = new int[int size here];
        }
        
        public int Min()
        {
           return array.Min();
        }
    
        public int Max()
        {
           return array.Max();
        }
    
        public void Insert(int value)
        {
            Array.Resize<int>(ref array, array.Count() + 1);
            array[array.Count() - 1] = value;
        }
    }
