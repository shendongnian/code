         string fileTemporary = "~/TempFiles/";
         string actualLoc = fileTemporary.Replace("~",HttpContext.Current.Server.MapPath(""));
         if(!Directory.Exists(actualLoc)) { Directory.CreateDirectory(actualLoc); }
         string newActualLoc = actualLoc + nameOfDocument + ".xlsx";
         string linkLoc = fileTemporary + nameOfDocument + ".xlsx";
        
         workSheet.SaveAs(newActualLoc);
         
         GC.Collect();
         GC.WaitForPendingFinalizers();
         System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workSheet);
         excelApp.Quit();
         System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
