    string[] names = System.IO.File.ReadAllLines(@"C:\Location\Names.txt");
    
    foreach (string line in names)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
