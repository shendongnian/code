    static void DirectoryTree(string directory, string indent = "")
    {
        try
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(directory);
            DirectoryInfo[] subDirectories = currentDirectory.GetDirectories();
            // Print all the sub-directories in a recursive way.
            for (int n = 0; n < subDirectories.Length; ++n)
            {
                // The last sub-directory is drawn differently.
                if (n == subDirectories.Length - 1)
                {
                    Console.WriteLine(indent + "└───" + subDirectories[n].Name);
                    DirectoryTree(subDirectories[n].FullName, indent + "    ");
                }
                else
                {
                    Console.WriteLine(indent + "├───" + subDirectories[n].Name);
                    DirectoryTree(subDirectories[n].FullName, indent + "│   ");
                }
            }
        }
        catch (Exception e)
        {
            // Here you could probably get an "Access Denied" exception,
            // that's very likely if you are exploring the C:\ folder.
            Console.WriteLine(e.Message);
        }
    }
    static void Main()
    {
        // Consider exploring a more specific folder. If you just type "C:\"
        // you are requesting to view all the folders in your computer.
        Console.WriteLine(@"C:\SomeFolder");
        DirectoryTree(@"C:\SomeFolder");
        Console.ReadKey();
    }
