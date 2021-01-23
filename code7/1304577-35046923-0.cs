    Console.WriteLine("Please enter the size of the array:");
    int size = int.Parse(Console.Read()); //you need to parse the input too
    int[] arr = new int[size];
    for(int i=0; i < arr.Length; i++)
    {
    	Console.WriteLine("Please enter the next number in the array, it's position is: " + i);
    	arr[i] = int.Parse(Console.Read()); //parsing to "int"
    }
