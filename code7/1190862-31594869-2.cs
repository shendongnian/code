    class Program
    {
        static Dictionary<string, HashSet<string>> groupMembers = new Dictionary<string, HashSet<string>>
        {
            {  "G4", new HashSet<string> { "G5","G6","U1","U2"} },
            {  "G1", new HashSet<string> { "G2","G3","G6"} },
            {  "G3", new HashSet<string> { "G4"} },
            {  "G2", new HashSet<string> { "G4","G1"} },
            {  "G5", new HashSet<string> { "G2"} },
            {  "G6", new HashSet<string> { "U2","G5"} },
        };
        static void Main()
        {
            foreach(string start in groupMembers.Keys)
            {
                HashSet<string> result = Init(start);
                Console.WriteLine("Start @ " + start + ": " + String.Join(", ", result.ToArray()));
            }
            
            Console.Write("Press Enter to Quit");
            Console.ReadLine();
        }
        static HashSet<string> Init(string start)
        {
            HashSet<string> visited = new HashSet<string>();
            Stack<string> notVisited = new Stack<string>();
            notVisited.Push(start);
            while (notVisited.Count > 0)
            {
                string next = notVisited.Pop();
                HashSet<string> children;
                if (visited.Add(next) && groupMembers.TryGetValue(next, out children))
                {
                    foreach (string member in children)
                    {
                        notVisited.Push(member);
                    }
                }
            }
            visited.Remove(start); // optionally remove "start" from the result?
            return visited;
        }
    }
