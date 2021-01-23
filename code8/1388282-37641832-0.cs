     class diagonalDifference
        {
            static void Main()
            {
    
        int N = Convert.ToInt16(Console.ReadLine());
        int[,] arr = new int[N, N];
        string str = string.Empty;
    
        for (int i = 0; i < N; ++i)
        {
            string[] strArr = Console.ReadLine().Split(' ');
            for (int j = 0; j < strArr.Length; ++j)
            {
                arr[i, j] = Convert.ToInt16(strArr[j]);
            }
        }
    
        int left = 0, right = N - 1, ldTotal = 0, rdTotal = 0;
        while (left <= (N-1))
        {
    
    
        ldTotal += arr[left, left];
    
    
        rdTotal += arr[left, right];
    Left++;
    Right--;
        }    
    
        Console.WriteLine(Math.Abs(ldTotal - rdTotal));
    
    
    
         }
            }
