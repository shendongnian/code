    public class Program
    {
        public static Random rnd = new Random();
        public static int[] array2;
        public static void Main()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            PrintArray(array);
            array[4] = rnd.Next();
            PrintArray(array);
            ModArray(array, 2);
            PrintArray(array);
            array2 = array;  //This makes array2 reference array1
            ModArray(array2, 8);  //Operate on the array2 reference
            PrintArray(array);    //Changes are reflected in array
            PrintArray(array2);   //And in array2
            Console.ReadKey(true);
        }
        public static void PrintArray(int[] array)
        {
            foreach (var e in array)
                Console.Write(e + ", ");
            Console.WriteLine();
        }
        public static void ModArray(int[] array, int i)
        {
            array[i] = rnd.Next();
        }
    }
