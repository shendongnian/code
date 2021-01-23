     // Note these fields are static so they persist between page-loads
     private static Dictionary<Int32,Boolean> _processes = new Dictionary<Int32,Boolean>();
     private static Int32 _processNum;
     
     ActionResult StartBackgroundTask() {
         
        Int32 num = _processNum++;
        _processes.Add( num, false );
        Thread thread = new Thread( delegate() {
             
            Process proc = new Process("MyExe.exe");
            proc.Start();
            proc.WaitForExit();
            
            _processes[ num ] = true; // marking as complete
        } );
        thread.Start();
        
        return View("BackgroundTaskIsRunning.aspx", num);
     }
     
     ActionResult GetBackgroundTaskState(Int32 num) {
        // Token `num` received from client.
        
        if( _processes[ num ] ) {
            return View("NextTask.aspx");
        } else {
            // Same view as before
            return View("BackgroundTaskIsRunning.aspx", num);
        }
     }
