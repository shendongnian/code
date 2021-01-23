    private static void Main()
            {
                // Read all the lines
                List<string> currentFileLines = File.ReadAllLines("read.txt").ToList();
    
                // Ask the user the line to start from
                Console.WriteLine("Enter the line you wish to delete from:");
    
                // Ask the user for start line
                int starLine = Convert.ToInt32(Console.ReadLine());
    
                // Ask the user the line to
                Console.WriteLine("Enter the line you wish to delete to:");
    
                // Ask the user for end line
                int endLine = Convert.ToInt32(Console.ReadLine());
    
                // Remove the lines
                currentFileLines.RemoveRange(starLine - 1, endLine - (starLine - 1));
    
                // Save the file
                File.WriteAllLines("read.txt", currentFileLines);
    
                // Show the line on the screen
                foreach (string line in currentFileLines)
                {
                    Console.WriteLine(line);
                }
    
                Console.ReadLine();
            }
