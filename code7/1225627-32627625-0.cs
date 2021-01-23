     RunTasks(new[] {new PrintTask(), new SaveTask(), new SendMailTask()});
     void RunTasks(int[] tasks)
     {
         foreach (var task in tasks)
         {
             task.Run();
         }
     }
     interface ITask
     {
         void Run();
     }
     class PrintTask : ITask
     {
          public void Run()
          {
              ....
          }
      }
      // etc...
