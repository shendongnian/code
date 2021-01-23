    foreach (Process2 process in Dte.Debugger.LocalProcesses) {
       if (process.ProcessID == processId) {
           process.Attach2();
           Dte.Debugger.CurrentProcess = process;
       }
    }
