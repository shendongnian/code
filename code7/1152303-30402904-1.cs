    string path = @"D:\Development\Latest\ConsoleApplication1\ConsoleApplication1\bin\Debug";
    string files = Directory.GetDirectoryRoot(path);
    
    var exeNotFoundList = new List<string>();
    
    for (int i = 0; i < chkListBox.CheckedItems.Count; i++)
    {
        var exeFilePathWithName = Path.Combine(path, chkListBox.Items[i].ToString() + ".exe");
        if(!File.Exists(exeFilePathWithName))
        {
             exeNotFoundList.Add(exeFilePathWithName);
             continue;
        }
        var process = new Process
            {
                StartInfo = new ProcessStartInfo
                   {
                      FileName = exeFilePathWithName
                    }
             };
        
       process.StartInfo.UseShellExecute = false;// Beacuse I  am using Process class
       process.StartInfo.CreateNoWindow = true;
       process.Start();
        
    }
    
    if(exeNotFoundList.Count > 0)
    {
        var errorMessage = String.Join(String.Empty, exeNotFoundList.ToArray());
        MessageBox.Show(errorMessage);
    }
