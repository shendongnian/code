    private List<int> listedProcesses = new List<int>();
    //...
    try
    {
        if(!listedProcesses.Contains(piis[i].Id)
        {
            listedProcesses.Add(piis[i].Id);
            processID = piis[i].Id.ToString();
            processName = piis[i].Name.ToString();
            processFileName = piis[i].FileName.ToString();
            processPath = piis[i].Path.ToString();
            output.Text += "\n\nSENT DATA : \n\t" + processID + "\n\t" + processName + "\n\t" + processFileName + "\n\t" + processPath + "\n";     
        }
    }
    
    //...
