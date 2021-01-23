    Console.WriteLine ("What is the answer of " + numero1 + " x " + numero2);
    string keyboardInput = Console.ReadLine();
    int answer;
    while (!int.TryParse(keyboardInput, out answer)) {
        Console.WriteLine("Invalid input, try again.");
        keyboardInput = Console.ReadLine();
    }
    // now read the insult
    string insult = Console.ReadLine(); 
 
