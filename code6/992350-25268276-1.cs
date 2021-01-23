            int counter = 0;
            string line;
            try
            {
                // Read the file and display it line by line.
                using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\AnswerFile.txt"))
                {
                    using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\outputFile.txt"))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            System.Console.WriteLine(line);
                            fileWriter.WriteLine(line);
                            counter++;
                        }
                    }
                }
                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.
                System.Console.ReadLine();
            }
            catch (System.IO.IOException ex)
            {
                // Handle the Error Properly Here
            }
