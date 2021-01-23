    class Program
    {
        // Tested with LibGit2Sharp version 0.21.0.176
        static void Main(string[] args)
        {
            // Load the repository with the path (Replace E:\mono2 with a valid git path)
            Repository repository = new Repository(@"E:\mono2");
            foreach (var branch in repository.Branches)
            {
                // Display the branch name
                System.Console.WriteLine(branch.Name);
            }
            System.Console.ReadLine();
        }
    }
