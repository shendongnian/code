    //routine to check if the file is locked
    protected virtual bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        //file is not locked
        return false;
    }
    public void SendFile(string filename, int maxTries)
    {
        bool done;
        while(true)
        {
            if(condition == true)
            {
                if(!IsFileLocked(filename))
                {
                    Process[] processes = Process.GetProcessByName("ThirdPartyApp");
                    foreach (var proc in processes)
                        proc.Kill();
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        client.Credentials = new System.Net.NetworkCredential("username", "password");
                        int count = 0;
                        done = false;
                        while (count < maxTries || !done)
                        {
                            try
                            {
                                client.UploadFile(ftpServer  + new FileInfo(filename).Name, "STOR", filename);
                                done = true;
                            }
                            catch(Exception ex)
                            {
                                System.Threading.Thread.Sleep(5000);
                                count++;
                            }
                        }
                        if (!done)
                        {
                            //handle the error
                        }
                    }
                    File.Delete(filename);
                    Process.Start("ThirdPartyApp");
                }
            }
        }
    }
