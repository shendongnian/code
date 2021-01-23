        const int SelectionSize = 4;
        
        private static long _variationsCount = 0;
        private static int[] _objects;
        private static int[] _arr;
        static void Main(string[] args)
        {
            _objects = new int[]{1,2,3,4,5,6,7,8,9,10};
            _arr = new int[SelectionSize];
            GenerateVariations(0);
            Console.WriteLine("Total variations: {0}", _variationsCount);
        }
        static void GenerateVariations(int index)
        {
            if (index >= SelectionSize)
                Print();
            else
                for (int i = 0; i < _objects.Length; i++)
                {
                    _arr[index] = i;
                    GenerateVariations(index + 1);
                }
        }
        private static void Print()
        {
            //foreach (int pos in arr)
            //{
            //    Console.Write(objects[pos] + " ");
            //}
            //Console.WriteLine();
            _variationsCount++;
        }
