            try
            {
                Process[] openApplications = Process.GetProcessesByName("excel");
                int proLen = openApplications.Length;
                if (proLen == 0)
                {
                    Console.WriteLine("The process does NOT exist or has exited...");
                    return 0;
                }
                foreach(Process p in openApplications)
                 {
                 //validate p for null/nothing
                 //get the name of the workbook using
                 //Use p.ActiveWorkbook.Name to get the file name.
                 }        
                return 1;
            }
            catch (Exception ex)
            {
     
            }
   
    
   
