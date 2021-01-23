    using Microsoft.Win32.TaskScheduler;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    ......................................
                    Task[] allTasks = TaskService.Instance.FindAllTasks(new Regex(".*")); // this will list ALL tasks for ALL users
                    foreach (Task tsk in allTasks)
                    {
                        //Do whatever you need here, for example:
                        Debug.WriteLine("TaskName:{0}; Path:{1}; Author:{2}; Principal: {3}; ", tsk.Name, tsk.Path, tsk.Definition.RegistrationInfo.Author, tsk.Definition.Principal.UserId);
                    }
