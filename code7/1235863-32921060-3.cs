    // the grid form takes the DataSource from the folders BindingSource
    var grid = new GridForm(this.folders.DataSource);
    grid.Show();
     // process each folder, making sure to get an instance of the
     // instances of the ViewModel, in this case by casting 
     // the DataSource object back to the List
    foreach(var folderStatus in (List<FolderStatusViewModel>) this.folders.DataSource)
    {
        var pi = new ProcessStartInfo();
        pi.FileName ="cmd.exe";
        pi.Arguments ="/c dir /s *.*";
        pi.CreateNoWindow = true;
    
        var p =  new Process(); 
        p.EnableRaisingEvents = true;
        p.Exited += (s,ee) => { 
            // here the instance of a FolderStatusViewModel
            // gets its Status property updated
            // all subscribers to the PropertyChanged event
            // get notified. BindingSource instances do subscribe to these
            // events, so that is why the magic happens. 
            if (p.ExitCode > 0)
            {
                folderStatus.Status = String.Format("fail {0}", p.ExitCode);
            } 
            else
            {
                folderStatus.Status = "succes";
            }
        };
        p.StartInfo = pi;
        p.Start();
    }
