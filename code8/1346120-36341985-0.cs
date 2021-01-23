    Console.WriteLine("Type to write..");
    while(true){
    	string line = Console.ReadLine(); // Read our user input
    	if(line.Equals("END")) break; // If our user enters 'END' stop reading and exit the while loop
    	streamw.WriteLine(line); // Otherwise, we write our line and carry on reading input
    }    
    streamw.Close();
