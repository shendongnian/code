    public void ExtractFiles()
    {
         var files = d.GetFiles("*.");
         int total = files.Count();
         var progressChange = 100/total;
    
        foreach (var file in files)
        {
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);
    
            if (!File.Exists(targetPath + file.Name))
            {
                Directory.Move(file.FullName, targetPath + file.Name);
            }
            else
            {
                File.Delete(targetPath + file.Name);
                Directory.Move(file.FullName, targetPath + file.Name);
            }
            //Here is the little bit change I did.
            pb.Dispatcher.BeginInvoke(new Action(()=>{
                pb.Value += progressChange;
            }));
            
        }
    }
