    int N = int.Parse(Console.ReadLine());
    int[] A = new int[N]; //Use the input limit here on array size
    int cL = 0; int CUL = 0;
    int j;
    for (j = 0; j < N; j++)
    {
        A[j] = int.Parse(Console.ReadLine());
        if (A[j] % 2 != 0)
        {
          CUL++;//no need to reassing result
        }
        else
        {
            cL++;
        }
    }
    if (cL > CUL)
    {
        Console.WriteLine("Ready for battle");
    }
    else
    {
        Console.WriteLine("Not ready");
    }
    Console.Readline(); // Just to halt the program to see the output. 
