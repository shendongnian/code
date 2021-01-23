    Console.WriteLine("Magical Name Reverser");       
    Console.WriteLine("Please Enter Your Name:");
    string name = Console.ReadLine();
    char[] cArray = name.ToCharArray();
    Array.Reverse(cArray);  
    string resultString = String.Join(" ", cArray);
    Console.WriteLine(resultString );   
    Console.WriteLine("Your name in reverse order is:");
