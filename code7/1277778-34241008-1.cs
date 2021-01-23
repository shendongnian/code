    static int array[10][10];
    //or like
    int[,] array = new int[,]
	{
	   <declare array structure>
	};
    int i, j, rowlength=10, columnlength=10, sum = 0; //assuming your order 10 as given example .To make it dynamic use array.Length
    sum = 0;
    for (j = 0; j < columnlength; ++j)
    {
        for (i = 0; i < rowlength; ++i)
        {
            sum = sum + array[i][j];
        }
        Console.WriteLine(String.Format("Summation of {0}th column is {1}", j,sum)); 
        sum=0;       
    }
