    public async Task<string> Solve(List<List<Node>> nodeList)
    {
        List<Task> taskList = new List<Task>();
        for (int i = 0; i < nodeList.Count(); i++)
        {
            int taskNo = i;
            Task<List<Node>> task = Task.Factory.StartNew((x) =>
            {
                List<Node> nodes = new List<Node>(nodeList[taskNo]); //replace i with taskNo
                Calculate(nodes);
                return nodes;
            }, taskNo);
            // remove Wait
            taskList.Add(task);
        }
        await Task.WhenAll(taskList); //Add this line
        Task<string> r = BuildReport(taskList);
        return r;
    }
