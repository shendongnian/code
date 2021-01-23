    string[] filePaths = Directory.GetFiles(writeDir);
    if (filePaths.Length == 0)
    {
        Console.WriteLine();
        Console.WriteLine(" Directory is Empty!");
        Console.WriteLine();
        Console.ReadLine();
    }
    else
    {
        for (int i = 0; i < filePaths.Length; ++i)
        {
            string path = filePaths[i];
            Console.WriteLine("File: " + System.IO.Path.GetFileName(path));
            Console.WriteLine();
        }
    }
