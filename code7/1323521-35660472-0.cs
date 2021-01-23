    Console.Write("Enter letter grade for class #{0} \n(use A, B, C, or D. Type 0 after all classes entered.): ", counter += 1);
    char userInput = char.Parse(Console.ReadLine());
    if ( !"ABCDF".ToCharArray().Contains(userInput) )
    {
    Console.WriteLine("Enter valid letter" ); 
    continue; // Start's the do loop over 
    }
