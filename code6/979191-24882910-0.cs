    // Calculate the cube of i.
    int cube = i*i*i;
   
    int sum = 0;
    string message;
    // Check if cube is even.
    if(cube%2==0)
    {
        sum = Enumerable.Range(0,cube).Where(x => x%2==0).Sum();
        message = "The sum of the even numbers in range [0,"+cube+"] is: ";
    }
    else // The cube is odd.
    {
        sum = Enumerable.Range(0,cube).Where(x => x%2==1).Sum();
        message = "The sum of the odd numbers in range [0,"+cube+"] is: ";
    }
    // Print the sum.
    Console.WriteLine(message+sum);
