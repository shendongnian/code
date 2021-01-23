    Console.WriteLine("Type a lowercase letter.");  
    char letter = char.Parse(Console.ReadLine());
    while(letter !='!')
    {
        if(char.IsLower(letter))
        {
            Console.WriteLine("OK. Type another lowercase letter");
        }
        else
        {
            Console.WriteLine("Error");
        }
        letter = char.Parse(Console.ReadLine()); 
    }
