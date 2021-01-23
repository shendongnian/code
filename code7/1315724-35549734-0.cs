            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(1000*60*60*23);
            FileStream fileStream = null;
            DateTime starttime = DateTime.Now;
            string str = "";
            ILogger ilogger = new Logger();
            ConfigurationSettings objXConfiguration = new ConfigurationSettings();
            System.Net.ServicePointManager.Expect100Continue = false;
            try
            {
                var username = objConfigurationSettings.UserName;
                var password = objConfigurationSettings.Password;
                using (HttpClient client = new HttpClient())
                {
                  
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/zip"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", username, password))));
                    client.DefaultRequestHeaders.Add("Connection", new string[] { "Keep-Alive" });
                    //=============================================================================================================
                    string FilePath = targetdir + "\\" + BackPlanName;
                    //  string CurrentDate = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second;
                    str = Project + ".zip";
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                    fileStream = new FileStream(FilePath + "\\" + str, FileMode.Create, FileAccess.Write);
                    
                    System.Net.ServicePointManager.Expect100Continue = false;
                   
                    var stream = await client.GetStreamAsync(sourceUrl).ConfigureAwait(continueOnCapturedContext: false);
                    await stream.CopyToAsync(fileStream,81920,cts.Token).ConfigureAwait(continueOnCapturedContext: true); 
           
          
                    string CalculateSize = CalculateFileSize(FilePath + "\\" + str);
                    object _lock = new object();
                    IXMLData ixmlBackup = new XMLData();
                    EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset);
                    waitHandle.WaitOne();
                    ixmlBackup.CreateBackupResultXML(UtlityHelper.GetFilePath(Settings.Default.BackupResult), BackPlanName, starttime.ToString(), DateTime.Now.ToString(), "Success", CalculateSize + " files copied");
                    waitHandle.Set();
                    // waitHandle.Dispose();
                    //==================Email when download compelte in window service===========================//
                    if (callbyservice == 1)
                    {
                        objXConfiguration = ixmlBackup.GetSettings("application");
                        ObservableCollection<BackupPlan> BackupPlanCollection = ixmlBackup.GetBackupPlan();
                        var CurrentPlan = BackupPlanCollection.Where(r => r.BackupPlanName == BackPlanName).FirstOrDefault();
                        DeleteFile(CurrentPlan.KeepBackupFileCount, CurrentPlan.TargetLocation + CurrentPlan.BackupPlanName, objXConfiguration.EmailAlertLevel, objConfigurationSettings.Service, ilogger);
                        if (objXConfiguration.EmailAlertLevel == "1" || objXConfiguration.EmailAlertLevel == "2")
                        {
                            UtlityHelper.SendEmail(DateTime.Now.ToString() + ":" + objConfigurationSettings.Service + ":The download for the backup profile "+BackPlanName+" completed.", 1);
                        }
                        ilogger.WriteBackLog(DateTime.Now.ToString() + ":" + objConfigurationSettings.Service + ":The download for the backup profile " + BackPlanName + " completed.");
                    }
                    //===========================================================================
                    return FilePath + "\\" + str;
                }
            }
            catch (Exception e)
            {
                IXMLData ixmlBackup = new XMLData();
                ixmlBackup.CreateBackupResultXML(UtlityHelper.GetFilePath(Settings.Default.BackupResult), BackPlanName, starttime.ToString(), DateTime.Now.ToString(), "Fail", e.Message);
                if (callbyservice == 1)
                {
                    ilogger.WriteBackupException(e);
                    objXConfiguration = ixmlBackup.GetSettings("application");
                    if (objXConfiguration.EmailAlertLevel == "0" || objXConfiguration.EmailAlertLevel == "2")
                    {
                        UtlityHelper.SendEmail(DateTime.Now.ToString() + ":" + objConfigurationSettings.Service + ": Exception:" + BackPlanName + ":" + e.Message, 1);
                    }
                }
                else
                {
                    throw e;
                }
                return null;
            }
           
            finally {
                fileStream.Flush();
                fileStream.Dispose();
                
            }
        }
