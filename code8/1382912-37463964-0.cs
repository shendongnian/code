    class Program
    {
        internal class BugDetails
        {
            public int Id { get; set; }
            public string State { get; set; }
            public string Severity { get; set; }
        }
        static void Main(string[] args)
        {
            var MyBugList = new BugDetails[]
            {
                new BugDetails() { Id = 1, State = "Active", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Critical" },
                new BugDetails() { Id = 1, State = "Active", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Active", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Resolved", Severity = "Medium" },
                new BugDetails() { Id = 1, State = "Active", Severity = "High" },
                new BugDetails() { Id = 1, State = "Active", Severity = "High" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "High" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "High" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "High" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "High" },
                new BugDetails() { Id = 1, State = "Closed", Severity = "High" },
            };
            var grouped = MyBugList.GroupBy(b => b.State).
                Select(stateGrp => stateGrp.GroupBy(b => b.Severity));
            foreach (var state in grouped)
            {
                Console.Write("{0}: ", state.First().First().State);
                foreach (var severity in state)
                {
                    Console.Write("{0}={1} ", severity.Key, severity.Count());
                }
                Console.WriteLine();
            }
        }
    }
