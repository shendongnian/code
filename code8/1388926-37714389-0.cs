        static void Main(string[] args)
        {
            var session = new EventLogSession();
            foreach (string name in session.GetLogNames())
            {
                Console.WriteLine(GetDisplayName(session, name));
            }
        }
