    Process[] processCollection = Process.GetProcesses();  
    private void ButtonOnClick(object seender, EventArgs e)
    {
        foreach (Process p in processCollection)  
        {  
            // make sure its a service 1st
            if(!Environment.UserInteractive){ 
            // iterate over processes and stuff into listbox
            var exename = Path.GetFileName(p.MainModule.FileName) 
            listBoxVar.Items.Add(exename);
            }
            // start/restart a process
            ProcessStartInfo startInfo = new ProcessStartInfo(exename);
            Process.Start(startInfo);
            // kill a process 
            p.Kill();
        }  
    }    
    
