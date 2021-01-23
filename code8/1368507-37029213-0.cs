    if (ddi.Exists)
            {
                logFile.WriteLine("Log Entry: {0}", String.Format("{0:f}", dt) + System.Environment.NewLine);
                foreach (File oFile in ddi.EnumerateFiles())
                {
                   if (oFile.Exists)
                    {
                        try
                        {
                            oFile.Delete();
                            logFile.WriteLine("{0} was deleted successfully.", destination_path + "\\" + oFile.Name);
                        }
                        catch (Exception ex)
                        {
                            logFile.WriteLine("The deletion process failed: {0}", ex.Message);
                        }
                    }
                }
                logFile.WriteLine(String.Concat(Enumerable.Repeat("-------", 25)));
                logFile.WriteLine();
            }
}
