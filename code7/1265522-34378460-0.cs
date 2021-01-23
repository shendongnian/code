    static int[] bubble(int [] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length - 1; j++)
                    if (mas[j] > mas[j + 1])
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }
    
            }
            foreach (var element in mas)
            {
                Console.WriteLine("Sorted elements are: {0}", element);
    
            }
    
        }
    
        static void Main(string[] args)
        {
            int[] mas = new int[5];
            Console.WriteLine("Please enter the elements of the array: ");
            for (int i = 0; i < 5; i++)
            {
                mas[i] = Convert.ToInt32(Console.ReadLine());
            }
            bubble(mas);
        }
