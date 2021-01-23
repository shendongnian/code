    public static void drawTextProgressBar(string stepDescription, int progress, int total)
    {
    	int totalChunks = 30;
    
    	//draw empty progress bar
    	Console.CursorLeft = 0;
    	Console.Write("["); //start
    	Console.CursorLeft = totalChunks + 1;
    	Console.Write("]"); //end
    	Console.CursorLeft = 1;
    
    	double pctComplete = Convert.ToDouble(progress) / total;
    	int numChunksComplete = Convert.ToInt16(totalChunks * pctComplete);
    
    	//draw completed chunks
    	Console.BackgroundColor = ConsoleColor.Green;
    	Console.Write("".PadRight(numChunksComplete));
    
    	//draw incomplete chunks
    	Console.BackgroundColor = ConsoleColor.Gray;
    	Console.Write("".PadRight(totalChunks - numChunksComplete));
    
    	//draw totals
    	Console.CursorLeft = totalChunks + 5;
    	Console.BackgroundColor = ConsoleColor.Black;
    
    	string output = progress.ToString() + " of " + total.ToString();
    	Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
    }
