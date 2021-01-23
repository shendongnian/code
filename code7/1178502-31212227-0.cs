    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PrincipalContext(ContextType.Domain))
            using (var user = UserPrincipal.Current)
            using (var userGroups = user.GetGroups())
            {
                PrintGroups(userGroups, 0);
            }
            Console.ReadLine();
        }
        static void PrintGroups(PrincipalSearchResult<Principal> groups, int level)
        {
            foreach (var group in groups)
            {
                Console.Write(new string('-', level * 3));
                Console.WriteLine(group.Name);
                using (var groupGroups = group.GetGroups())
                {
                    PrintGroups(groupGroups, level + 1);
                }
            }
        }
    }
