        // Cancel the task when Application is trying to exit.
        Application.ApplicationExit += (o,e)=>
        {
            tokenSource.Cancel(); 
        };
        Task.WhenAll(task).ContinueWith(_=>{
          Application.Exit();
        });
    }
