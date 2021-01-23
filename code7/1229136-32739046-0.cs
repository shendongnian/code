    string configfilename = path + "config.ini";
    string installerfilename = path + "installer.ini";
    
    var link = File.ReadLines(path + "config.ini").ToArray();
    var lin = File.ReadLines(path + "installer.ini").ToArray();
    IEnumerable<string> newInstaller = lin;
    foreach (var txt in link)
     {
    
         if (txt.Contains("PLP="))
         {
            var PLPPath = txt.Split('=')[1];
            newInstaller = newInstaller.Select(line => Regex.Replace(line, @"fileInstallationKey=.*", "fileInstallationKey=" + PLPPath));                   
         }
         if (txt.Contains("Output="))
         {
             var outputPath = txt.Split('=')[1];
             newInstaller = newInstaller.Select(line => Regex.Replace(line, @"outlog=.*", "outlog=" + outputPath));  
         }
     }
    newInstaller = newInstaller.Select(line => Regex.Replace(line, @"license=.*", "license=yes"));
    newInstaller = newInstaller.Select(line => Regex.Replace(line, @"lmgr_files=.*", "lmgr_files=false"));
    newInstaller = newInstaller.Select(line => Regex.Replace(line, @"lmgr_service=.*", "lmgr_service=true"));
    string strWrite = string.Join("", newInstaller);
    File.WriteAllText(installerfilename,strWrite);
