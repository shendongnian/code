    class Program
    {
        public double AskDnoubleQuestion(string message){
            do {
            Console.Write(message);
            var input = Console.ReadLine();
        
            if (String.IsNullOrEmpty(input)){
                Console.WriteLine("Input is required");
                continue;
             }
             double result;
             if (!double.TryParse(input, out result)){
               Console.WriteLine("Invalid input - must be a valid double");
               continue;
             }
             return result;
        }
        static void Main(string[] args)
        {
            Board board = new Board();
        board.lengthOfboard = AskDoubleQuestion("What is the length of your board in inches?");
        board.widthOfboard = AskDoubleQuestion(askQuestion("What is the width of your board in inches?");
        board.thicknessOfboard = AskDoubleQuestion(askQuestion("What is the thickness of your board in inches?");
        Console.WriteLine("Your board has {0} board feet.", board.CalcBoardFt());
        Console.ReadLine();
    }
