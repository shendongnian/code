        const int maxThreads = 5;
        Semaphore sm = new Semaphore(maxThreads, maxThreads); // maximum concurrent threads
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                sm.WaitOne();
                Thread tr = new Thread(new ThreadStart(ProcessItems));
                tr.Name = Convert.ToString(dt.Rows[i]["Id"]);
                tr.IsBackground = true;
                tr.Start();
             }
             finally
             {
                 sm.Release();
             }
        }
    // You don't need the timer anymore
    // Wait for the semaphore to be completely released
            for (int i=0; i<maxThreads ; i++)
                sm.WaitOne();
            sm.Release(maxThreads);
            if (Image_IDsToDelete != "")
            {
                RetailHelper.ExecuteNonQuery("Delete from images where Image_ID in (" + Image_IDsToDelete + ")");
            }
            if (ErrorText != "")
            {
                NotUploadedFiles = NotUploadedFiles + ".";
                XtraMessageBox.Show("Unable to connect to server. The following files were not uploaded:" + System.Environment.NewLine + NotUploadedFiles + ".", Global.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    //The method which is used to upload images
    private void ProcessItems()
    {
        //if (dict.Count == 0)
        //    pthread.Suspend();
        //ArrayList toRemove = new ArrayList();
        try
        {
            sm.WaitOne(); 
            try
            {
                //int NoofAttempts = 0;
                //foreach (DictionaryEntry e in dict)
                //{
                    //Thread.Sleep(500);
                  dr = dt.Select("Is_Uploaded=0 And Id=" + Thread.CurrentThread.Name).FirstOrDefault();
                    uxImageAndProgress pbCtl = panelControl1.Controls[dr["Image_ID"].ToString()] as uxImageAndProgress;
                    //NoofAttempts = 0;
                    string Path = "";
                    if (ftpPath == "")
                    {
                        Path = Global.FTPRemotePath + "/ProductImages/" + dr["Image_ID"] + dr["Extension"].ToString();
                    }
                    else
                    {
                        Path = ftpPath + dr["Image_ID"] + dr["Extension"].ToString();
                    }
                    //object[] loader = e.Value as object[];
                    int length = (int)(dr["ActualData"] as byte[]).Length;
                    Stream stream = new MemoryStream(dr["ActualData"] as byte[]);
                    byte[] rBuffer = ReadToEnd(stream);
                    int d = length - (int)stream.Length;
                    d = Math.Min(d, rnd.Next(10) + 1);
                    if (ftpRequest == null)
                    {
                        try
                        {
                            #region New Code
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(Path));
                            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                            ftpRequest.Credentials = new NetworkCredential(Global.FTPLogIn, Global.FTPPassword);
                            ftpRequest.UsePassive = true;
                            ftpRequest.UseBinary = true;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Timeout = 20000;
                            ftpRequest.ContentLength = length;
                            byte[] buffer = new byte[length > 4097 ? 4097 : length];
                            int bytes = 0;
                            int total_bytes = (int)length;
                            System.IO.Stream rs = ftpRequest.GetRequestStream();
                            while (total_bytes > 0)
                            {
                                bytes = stream.Read(buffer, 0, buffer.Length);
                                rs.Write(buffer, 0, bytes);
                                total_bytes = total_bytes - bytes;
                            }
                            dr["Is_Uploaded"] = 1;
                            dt.AcceptChanges();
                            ftpRequest = null;
                            pbCtl.Is_Uploaded = true;
                            rs.Close();
                            #endregion
                        }
                        catch (Exception eeex)
                        {
                            ftpRequest = null;
                            if (ErrorText == "")
                                ErrorText = eeex.Message.ToString();
                            else
                                ErrorText = ErrorText + "," + eeex.Message.ToString();
                            if (Image_IDsToDelete == "")
                                Image_IDsToDelete = dr["Image_ID"].ToString();
                            else
                                Image_IDsToDelete = Image_IDsToDelete + "," + dr["Image_ID"].ToString();
                            if (NotUploadedFiles == "")
                                NotUploadedFiles = Convert.ToString(dr["FileName"]);//dr["Image_ID"] + dr["Extension"].ToString();
                            else
                                NotUploadedFiles = NotUploadedFiles + ", " + Convert.ToString(dr["FileName"]); 
                            dr["Is_Uploaded"] = true;
                            dt.AcceptChanges();
                            ftpRequest = null;
                            pbCtl.Is_Uploaded = true;
                            pbCtl.Is_WithError = true;
                        }
                    }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), Global.Header, MessageBoxButtons.OK);
                //pthread.Suspend();
            }
        }
        finally
        {
             sm.Release();
        }
    }
