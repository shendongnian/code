    private void TerminateAll_Click(object sender, RoutedEventArgs e) 
    {
        List<string> processes = // get the list
        TerminateAll(processes);
    }
    
    public void TerminateAll(List<string> processes)
    {
       foreach(string process in processes)
         Terminate(process);
    }
    private void Terminate(string process)
    {
      // terminate the process
    }
