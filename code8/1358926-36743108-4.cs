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
                double[] numbers = System.IO.File.ReadAllLines(@"C:\WS1_Rain.txt").Select(p => double.Parse(p)).ToArray();
                int len = 9;
    
                Console.WriteLine("QuickSort By Recursive Method");
                QuickSort_Recursive(numbers, 0, len - 1);
                for (int i = 0; i < 9; i++)
                    Console.WriteLine(numbers[i]);
    
                Console.WriteLine();
                Console.ReadKey();
            }
