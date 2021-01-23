    int[] a = new int[] {1,2,3,4,5,6,7,8,9,10};
    int[,] b;
    if(a % 3 != 0)
    {
        b = new int[a/3+1,3];
    }
    else
    {
        b = new int[a/3, 3];
    }
    for(int i = 0; i< a.length;i++)
    {
        b[a/3,a%3] = a[i];
    }
