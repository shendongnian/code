    // other code omitted
    foreach(DataRow folderStatus in ((DataTable) this.folders.DataSource).Rows)
    {
         // other code omitted
         p.Exited += (s,ee) => { 
             if (p.ExitCode > 0)
             {
                 folderStatus["Status"] = String.Format("fail {0}", p.ExitCode);
             } 
             else
             {
                 folderStatus["Status"] = "succes";
             }
         };
         // other code omitted
    }
