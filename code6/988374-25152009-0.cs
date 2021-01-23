    public void ExtractFiles()
    {
         var total = d.GetFiles("*.").count();
         var progressChange =  100/total;
         
        foreach (var file in d.GetFiles("*."))
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
            pb.Value += progressChange;
        }
    }
