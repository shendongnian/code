    public static void GetDirectories(string path, bool recursive)
    {
        Console.WriteLine(path); // write the name of the current directory
        if (recursive) // if we want to get subdirectories
        { 
            try // getting directories will throw an error if it is a path you don't have access to
            {
                foreach (var child in Directory.GetDirectories(path)) // get all the subdirectories for the given path
                {
                    GetDirectories(child, recursive); // call our function for each sub directory
                }
            }
            catch (UnauthorizedAccessException ex) // handle unauthorized access errors
            {
                Console.WriteLine(string.Format("You don't have permission to view subdirectories of {0}",path));
            }
                    
        }
    }
