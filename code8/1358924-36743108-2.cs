    class Program
        {
            static public int Partition(double[] numbers, int left, int right)
            {
                double pivot = numbers[left];
                while (true)
                {
                    while (numbers[left] < pivot)
                        left++;
    
                    while (numbers[right] > pivot)
                        right--;
    
                    if (left < right)
                    {
                        double temp = numbers[right];
                        numbers[right] = numbers[left];
                        numbers[left] = temp;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
    
            static public void QuickSort_Recursive(double[] arr, int left, int right)
            {
                // For Recusrion
                if (left < right)
                {
                    int pivot = Partition(arr, left, right);
    
                    if (pivot > 1)
                        QuickSort_Recursive(arr, left, pivot - 1);
    
                    if (pivot + 1 < right)
                        QuickSort_Recursive(arr, pivot + 1, right);
                }
            }
    
            static void Main(string[] args)
            {
                double[] numbers = { 3.5, 8.5, 7.6, 5.1, 2.1, 1.7, 9.9, 6.2, 4 };
                int len = 9;
    
                Console.WriteLine("QuickSort By Recursive Method");
                QuickSort_Recursive(numbers, 0, len - 1);
                for (int i = 0; i < 9; i++)
                    Console.WriteLine(numbers[i]);
    
                Console.WriteLine();
                Console.ReadKey();
            }
