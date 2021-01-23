        string[] Bob = { "Bob", "Belcher", "800-123-12345", "13483" };
        string[] James = { "James", "Bond", "555-123-6758", "13484" };
        string[] Clark = { "Clark", "Kent", "111-222-3333", "13485" };
        // create a collection of arrays
        var list = new List<string[]> { Bob, James, Clark };
        string input = Console.ReadLine();
        // User types in Bob
        // Search in the list. Compare user input to [0] element of each string array in the list.
        var userChoice = list.FirstOrDefault(x => x[0] == input);
        if (userChoice != null)
        {
            Console.WriteLine(userChoice[3]);
        }
