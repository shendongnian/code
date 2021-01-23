    static void Main(string[] args) {
        var line = System.Console.ReadLine().Trim();
    	
        while(line!="exit") {
        	myOperationCommand(line);
        	line = System.Console.ReadLine().Trim(); // read input again
        }
        
        System.Console.WriteLine("End!\n");
    }
    
    // Do some operation...
    static void myOperationCommand(string line) {
    	switch(line) {
        	case "checkprice":
        		System.Console.WriteLine("price of foo is 42$");
        		break;
    		default: 
				System.Console.WriteLine("Command not reconized: " + line);
    			break;
    	}
    }
