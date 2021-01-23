    [HttpPost]
        public async Task<IHttpActionResult> ImportFile(int procId, int fileId)
    {
    string importErrorMessage = String.Empty;
    // Get excel file and read it
    string path = FilePath(fileId);
    DataTable table = GetTable(path);
    // Add record for start process in table Logs
    using (var transaction = db.Database.BeginTransaction()))
    {
        try
        {
            db.uspAddLog(fileId, "Process Started", "The process is started");
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            importErrorMessage = e.Message;
            return BadRequest(importErrorMessage);
        }
    }
             //Start long running process in new thread
             Task.Factory.StartNew(()=>{
            
             using (myHelper helper = new myHelper())
            {
               helper.StartImport(procId, fileId, table, ref importErrorMessage);
              //** As this code is running background thread you cannot return anything here. You just need to store status in database. 
              
             //if (!String.IsNullOrEmpty(importErrorMessage))
             //return BadRequest(importErrorMessage);
           }
            
            });
    //You always return ok to indicate background process started
    return Ok(true);
    }
