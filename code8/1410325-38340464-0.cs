    class Program
    {
        static void FillArray(out int[,] array)
        {
            // 2 rows with 100 columns
            array=new int[2, 100];
            for (int i=0; i<100; i++)
            {
                array[0, i]=i;
                array[1, i]=100-i;
            }
        }
        static void Main(string[] args)
        {
            int[,] array2D;
            FillArray(out array2D);
            var first_row=new int[100];
            var second_row=new int[100];
            int bytes=sizeof(int);
            Buffer.BlockCopy(array2D, 0, first_row, 0, 100*bytes);
            // 0, 1, 2, ...
            Buffer.BlockCopy(array2D, 100*bytes, second_row, 0, 100*bytes);
            // 100, 99, 98, ..
        }
    }
