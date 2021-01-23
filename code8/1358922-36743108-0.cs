    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace sortQuick
    {
        class quickSort
        {
    
            private double[] array = new double[1010];
            private int len;
    
            public void QuickSort()
            {
                sort(0, len - 1);
            }
    
            public void sort(int left, int right)
            {
                int leftend, rightend;
                double pivot;
    
                leftend = left;
                rightend = right;
                pivot = array[left];
    
                while (left < right)
                {
                    while ((array[right] >= pivot) && (left < right))
                    {
                        right--;
                    }
    
                    if (left != right)
                    {
                        array[left] = array[right];
                        left++;
                    }
    
                    while ((array[left] <= pivot) && (left < right))
                    {
                        left++;
                    }
    
                    if (left != right)
                    {
                        array[right] = array[left];
                        right--;
                    }
                }
    
                left = leftend;
                right = rightend;
    
                if (left < pivot)
                {
                    sort(left, pivot - 1);
                }
    
                if (right > pivot)
                {
                    sort(pivot + 1, right);
                }
            }
    
            public static void Main()
            {
                quickSort q_Sort = new quickSort();
    
                double[] years = System.IO.File.ReadAllLines(@"C:\WS1_Rain.txt");
                IEnumerable<double> yearArray = years.Select(item => double.Parse(item));
                double[] array = yearArray.ToArray();
    
                q_Sort.array = array;
                q_Sort.len = q_Sort.array.Length;
                q_Sort.QuickSort();
    
                for (int j = 0; j < q_Sort.len; j++)
                {
                    Console.WriteLine(q_Sort.array[j]);
                }
                Console.ReadKey();
            }
        }
    }
