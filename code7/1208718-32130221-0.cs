    public static class ProcessTree
    {
        private static Dictionary<int, ProcessTreeNode> processes;
        private static DateTime timeFilled = DateTime.MinValue;
        private static TimeSpan timeout = TimeSpan.FromSeconds(3);
        static ProcessTree()
        {
            processes = new Dictionary<int, ProcessTreeNode>();
        }
        public static List<int> GetChildPids(int pid)
        {
            if (DateTime.Now > timeFilled + timeout) FillTree();
            return processes[pid].Children;
        }
        public static int GetParentPid(int pid)
        {
            if (DateTime.Now > timeFilled + timeout) FillTree();
            return processes[pid].Parent;
        }
        private static void FillTree()
        {
            DateTime start = DateTime.Now;
            var results = new List<Process>();
            // query the management system objects for any process that has the current
            // process listed as it's parentprocessid
            string queryText = string.Format("select processid, parentprocessid from win32_process");
            using (var searcher = new ManagementObjectSearcher(queryText))
            {
                foreach (var obj in searcher.Get())
                {
                    object pidObj = obj.Properties["processid"].Value;
                    object parentPidObj = obj.Properties["parentprocessid"].Value;
                    if (pidObj != null)
                    {
                        int pid = Convert.ToInt32(pidObj);
                        if (!processes.ContainsKey(pid)) processes.Add(pid, new ProcessTreeNode(pid));
                        ProcessTreeNode currentNode = processes[pid];
                        if (parentPidObj != null)
                        {
                            currentNode.Parent = Convert.ToInt32(parentPidObj);
                        }
                    }
                }
            }
            DateTime num1 = DateTime.Now;
            foreach (ProcessTreeNode node in processes.Values)
            {
                if (node.Parent != 0 && processes.ContainsKey(node.Parent)) processes[node.Parent].Children.Add(node.Pid);
            }
            timeFilled = DateTime.Now;
            StaticLogger.Log(string.Format("ProcessTree.FillTree() completed in {0} seconds. 1={1}  2={2}",
                (timeFilled - start).TotalSeconds,
                (num1 - start).TotalSeconds,
                (timeFilled - num1).TotalSeconds));
        }
    }
    public class ProcessTreeNode
    {
        public List<int> Children { get; set; }
        public int Pid { get; private set; }
        public int Parent { get; set; }
        public ProcessTreeNode(int pid)
        {
            Pid = pid;
            Children = new List<int>();
        }
    }
