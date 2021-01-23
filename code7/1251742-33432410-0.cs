    using System;
    
    namespace CodeStorm
    {
        class CountingTriangles
        {
            public static double square(int x)
            {
                return Math.Pow(x, 2);
            }
    
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                string[] A_temp = Console.ReadLine().Split(' ');
                int[] A = Array.ConvertAll(A_temp, Int32.Parse);
                // TODO: sort A[]  (if it is not already always sorted)
                // TODO: create an array of the square-valuee
                int[] Asquares = ....
                int n_m_2= n-2;
                int n_m_1= n-1;
                int acute = 0, right = 0, obtuse = 0;
                for (int i = 0; i < n_m_2; i++) 
                {
                    for (int j = i + 1; j < n_m_1; j++) 
                    {
                        int k = j + 1;
                        int AiPlusAj = A[i] + A[j];
                        while (k < n )
                        {
                            if(AiPlusAj <= A[k]){
                              break; 
                            }
 
                            int squareSum= Asquares[i] + Asquares[j];
                            else if (squareSum > Asquares[k])
                            {
                                acute++;
                            }
                            else if (squareSum < Asquares[k])
                            {
                                obtuse++;
                            }
                            else
                            {
                                right++;
                            }
                            k++;
                        }
                    }
                }
                Console.WriteLine(acute + " " + right + " " + obtuse);
                Console.ReadLine();
            }
        }
    }
