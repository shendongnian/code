    Timer _taskTimer = new Timer(ProcessPendingTasks, null, 100, 333);
 
    private void ProcessPendingTasks(object x)
             {
               _status = Statuskatalog.Busy;
                 _taskTimer.Change(Timeout.Infinite, Timeout.Infinite);
                 Action currentTask;
                 while( _clientActions.TryDequeue( out currentTask ))
                 {
                     var task = new Task(currentTask);
                     task.Start();         
                     task.Wait();
                 }
    
             _status=Statuskatalog.Idle;
             }
