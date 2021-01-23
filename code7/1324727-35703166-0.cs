    static void PrintKeys(RegistryKey rkey)
    {
        // Retrieve all the subkeys for the specified key.
        String[] names = rkey.GetSubKeyNames();
        Console.WriteLine("Subkeys of " + rkey.Name);
        Console.WriteLine("-----------------------------------------------");
        // Print the contents of the array to the console.
        foreach (String s in names)
        {
            Console.WriteLine(s);
        }
    }
