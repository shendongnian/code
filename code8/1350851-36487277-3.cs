    Console.Write("Enter your Length: ");
    // Read and parse your length
    int length = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter your Width: ");
    // Read and parse your width
    int width = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter your Height: ");
    // Read and parse your height
    int height = Convert.ToInt32(Console.ReadLine());
    // Now you have all of your dimensions so calculate
    int totalDims = length * width * height;
    // Since you are performing division, you could have a fractional
    // value here, so you might want to use another type like decimal
    decimal cubicFeet = totalDims / 1728m;
    // Output your result
    Console.WriteLine("Your total cubic feet is " + cubicFeet);
