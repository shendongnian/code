    class Program
    {
        private class MyGroup
        {
            public string Identity { get; set; }
            public HashSet<string> MemberOf { get; set; }
            public HashSet<string> Members { get; set; }
            public HashSet<string> Users { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Identity: " + Identity);
                sb.AppendLine("MemberOf: " + String.Join(", ", MemberOf.ToArray()));
                sb.AppendLine("Members: " + String.Join(", ", Members.ToArray()));
                sb.AppendLine("Users: " + String.Join(", ", Users.ToArray()));
                return sb.ToString();
            }
        }
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
            Dictionary<string, MyGroup> output = new Dictionary<string, MyGroup>();
            // First Pass: Figure out Children and Users
            foreach(string start in groupMembers.Keys)
            {
                MyGroup group = new MyGroup();
                group.Identity = start;
                HashSet<string> Users = new HashSet<string>();
                group.Members = GetChildrenAndUsers(start, ref Users);
                group.Users = Users;
                output.Add(start, group);
            }
            // Second Pass: Figure out the Parents:
            List<string> outer = output.Keys.ToList();
            List<string> inner = output.Keys.ToList();
            foreach (string outerKey in outer)
            {
                MyGroup group = output[outerKey];
                group.MemberOf = new HashSet<string>();
                foreach (string innerKey in inner)
                {
                    MyGroup group2 = output[innerKey];
                    if (group2.Identity != group.Identity)
                    {
                        if(group2.Members.Contains(group.Identity))
                        {
                            group.MemberOf.Add(group2.Identity);
                        }
                    }
                }
            }
            // Display the results:
            foreach(MyGroup group in output.Values)
            {
                Console.Write(group.ToString());
                Console.WriteLine("--------------------------------------------------");
            }
            Console.Write("Press Enter to Quit");
            Console.ReadLine();
        }
        static HashSet<string> GetChildrenAndUsers(string start, ref HashSet<string> Users)
        {
            HashSet<string> visited = new HashSet<string>();
            Stack<string> notVisited = new Stack<string>();
            notVisited.Push(start);
            while (notVisited.Count > 0)
            {
                string next = notVisited.Pop();
                HashSet<string> children;
                if (!groupMembers.ContainsKey(next))
                {
                    Users.Add(next);
                }
                else
                {
                    if (visited.Add(next) && groupMembers.TryGetValue(next, out children))
                    {
                        foreach (string member in children)
                        {
                            notVisited.Push(member);
                        }
                    }
                }
            }
            visited.Remove(start); // optionally remove "start" from the result?
            return visited;
        }
    }
