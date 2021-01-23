    using Microsoft.Win32.TaskScheduler;
    static void Main(string[] args)
    {
        using (TaskService ts = new TaskService())
        {
            ts.NewTaskFromFile("C:\\Path\\To\\file.xml");
        }
    }
