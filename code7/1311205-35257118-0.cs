    Console.WriteLine("\nEnter the number of wheels of a car");
    string userInput = Console.ReadLine();
    int numOfWheels;
    if(Int32.TryParse(userInput, out numOfWheels))
        myCar.NumOfWheels = numOfWheels;
    else
    {
       Console.WriteLine("You haven't typed a valid number for wheels!")
       return;
    }
    Console.WriteLine("Enter the color of the car");
    myCar.Color = Console.ReadLine();
