        using (TaskService ts = new TaskService())
        {
            TaskEventLog log = new TaskEventLog("taskPath");
            List<ListViewItem> c = new List<ListViewItem>(100);
            foreach (TaskEvent item in log)
            {
                Console.WriteLine(item.Level);
                Console.WriteLine(item.TimeCreated);
                Console.WriteLine(item.EventId);
                Console.WriteLine(item.TaskCategory);
                Console.WriteLine(item.OpCode);
                Console.WriteLine(item.ActivityId);
            }
        }
