    int space = 0;
    do
    {
        // Prints initial spaces
        for(int x = 0; x < space; x++)
            Console.Write("-");
        // Print the number for the current value of width        
        for (int i = 0; i < width; i++)
            Console.Write(number);
            
        // Print final spaces - 
        // Not really needed 
        for (int x = 0; x < space; x++)
            Console.Write("-");
        // Start the new line
        Console.WriteLine();
        //Decrease width by one space for each end (2)
        width-=2;
        // Increment the spaces to print before and after
        space++;
    } while (width > 0);
