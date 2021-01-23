    System.Diagnostics.Process[] procArray;
    Dictionary<string,int> applications = new Dictionary<string,int>();
    procArray = System.Diagnostics.Process.GetProcesses();
    for (int i = 0; i < procArray.Length; i++)
    {
         if (procArray[i].MainWindowTitle.Length > 0)
         {
                applications.Add(procArray[i].MainWindowTitle, procArray[i].Id);
         }
    }
    foreach (KeyValuePair<string, int> app in applications)
    {
        comboBox.Items.Add(app.Key);
    }
