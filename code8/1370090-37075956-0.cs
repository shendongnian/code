    private void label6_Click(object sender, EventArgs e)
    {
        string tempPath = Path.GetTempPath();
        DirectoryInfo di = new DirectoryInfo(tempPath);
    
        foreach (FileInfo file in di.GetFiles())
        {
            try 
            { 
                file.Delete();
            }
            catch (IOException) 
            {
                // ignore all IOExceptions:
                //   file is used (e.g. opened by some other process)
            }
            catch (SecurityException) {
                // ignore all SecurityException: 
                //   no permission
            } 
            catch (UnauthorizedAccessException) 
            {
                // ignore all UnauthorizedAccessException: 
                //   path is directory
                //   path is read-only file 
            }
        }
    }
