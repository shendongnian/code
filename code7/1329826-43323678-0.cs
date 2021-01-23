    private static void CallProgram(int jobID, int productID)
    {
        DataTable dtProduct = GetProductInformation(productID);
        try
        {
            // 1
            // Initialize process information.
            //
            ProcessStartInfo p = new ProcessStartInfo();
            p.WorkingDirectory = string.Format(@"{0}", dtProduct.Rows[0]["ProgramDirectory"].ToString());
            p.FileName = dtProduct.Rows[0]["ProgramName"].ToString();
            // 2
            // add arguements
            string[] args = { jobID.ToString() };
            p.Arguments = String.Join(" ", args);
            p.Verb = "runas";
             //p.WindowStyle = ProcessWindowStyle.Hidden;
            p.CreateNoWindow = true;
            // 3.
            // Start process and wait for it to exit
            //
            Process x = Process.Start(p);
            //x.WaitForExit();
        }
        catch (Exception ex)
        {
            string function = MethodBase.GetCurrentMethod().Name;
            ErrorHandling(function, ex.Message, ex.StackTrace);
            throw;
        }
    }
