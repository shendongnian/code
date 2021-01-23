    static void Main(string[] args) {
        var line = System.Console.ReadLine().Trim();
    	
        while(line!="exit") {
        	MyOperation(line);
        	line = System.Console.ReadLine().Trim();
        }
        
        System.Console.WriteLine("End!\n");
    }
    static void MyOperation(string line) {
        System.Console.WriteLine("Input value: " + line);
    }
