    public static void ReadWriteFile(string filePath)
    {
        if (filePath == null) throw new ArgumentNullException();
        if (!File.Exists(filePath)) throw new FileNotFoundException("filePath");
        var newLines = new List<string>();
        bool cancelled = false;
        bool promptForInput = true;
        using (var reader = new StreamReader(filePath))
        {
            int lineNumber = 0;
            string currentLine;
            while ((currentLine = reader.ReadLine()) != null)
            {
                if (promptForInput)
                {
                    Console.WriteLine("#{0}: {1}", ++lineNumber, currentLine);
                    Console.Write("[K]eep or [D]elete this line, [S]ave changes, " + 
                        "or [C]ancel (default = 'K'): ");
                    var input = Console.ReadKey();
                    Console.WriteLine();
                    if (input.Key == ConsoleKey.D)
                    {
                        Console.WriteLine("Marked line #{0} for deletion", lineNumber);
                        continue;
                    }
                    if (input.Key == ConsoleKey.C)
                    {
                        Console.WriteLine("Cancelling operation. No changes saved.");
                        cancelled = true;
                        break;
                    }
                    if (input.Key == ConsoleKey.S)
                    {
                        promptForInput = false;
                    }
                }
                newLines.Add(currentLine);
            }
        }
        if (!cancelled)
        {
            // By overwriting with the saved lines, we effectively delete the other lines
            Console.WriteLine("Deleting selected lines from file...");
            File.WriteAllLines(filePath, newLines);
        }
    }
