    Console.WriteLine("Please enter the size of the array:");
    int size;
    
    while(!int.TryParse(Console.ReadLine(), out size))
    {
        Console.WriteLine("Please enter the size of the array:");
    }
    
    var arr = new int[size];
    
    for (int i = 0; i < size; i++)
    {
        Console.WriteLine("Please enter the next number in the array, it's position is: " + i);
        int currentElement;
        while (!int.TryParse(Console.ReadLine(), out currentElement))
        {
            Console.WriteLine("Please enter the next number in the array, it's position is: " + i);
        }
    
        arr[i] = currentElement;
    }
