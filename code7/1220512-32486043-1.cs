    public void changepy()
    {
         if (File.Exists(pypath))
         {
             string machineName = System.Environment.MachineName;
             string content = File.ReadAllText(pypath);
             content = content.Replace("Call of Duty Tools", machineName);
    
             File.WriteAllText(pypath, content);
             MessageBox.Show("Changed");
         }
         else
         {
         }
    }
