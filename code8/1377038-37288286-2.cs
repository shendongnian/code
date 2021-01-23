    using System;
    using Microsoft.Win32.TaskScheduler;
    
    namespace ListTasks
    {
        class Program
        {
            static void EnumFolderTasks(TaskFolder fld)
            {
                foreach (Task task in fld.Tasks)
                    DisplayTask(task);
    
                foreach (TaskFolder sfld in fld.SubFolders)
                    EnumFolderTasks(sfld);
            }
    
            static void DisplayTask(Task t)
            {
                Console.WriteLine("Task: {0, -60} Active: {1, -5} Enabled: {2, -5}", 
                                  t.Name, t.IsActive, t.Enabled);
            }
    
            static void Main(string[] args)
            {
                using (TaskService ts = new TaskService())
                {
                    EnumFolderTasks(ts.RootFolder);
                }
            }
        }
    }
