    Dictionary<string, List<Process>> procs = new Dictionary<string, List<Process>>()
    {
        {"With Exception",new List<Process>()},
        {"Without Exception",new List<Process>()}
    };
    foreach (var proc in Process.GetProcesses())
    {
        Exception ex = null;
        try
        {
            //based on your example,many other properties will also throw
            ProcessPriorityClass temp = proc.PriorityClass;
        }
        catch (Exception e)
        {
             ex = e;
        }
        finally
        {
             if (ex == null)
                 procs["Without Exception"].Add(proc);
             else
                 procs["With Exception"].Add(proc);
        }
    }
    
    var processQuerySet = from process in procs["Without Exception"]
                          group process by process.PriorityClass into priorityGroup
                          select priorityGroup;
    
    foreach (var priority in processQuerySet)
    {
         Console.WriteLine(priority.Key.ToString());
         foreach (var process in priority)
         {
             Console.WriteLine("\t{0}   {1}", process.ProcessName, process.WorkingSet64);
         }
    }
