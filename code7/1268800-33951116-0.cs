    string filename = "mylist.xls";
    var excelProcesses = Process.GetProcessesByName("excel");
    foreach (var process in excelProcesses)
    {
      if (process.MainWindowTitle.EndsWith(filename)) 
      {
         process.Kill();
      }
    }
