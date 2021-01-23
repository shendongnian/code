    private DateTime _lastRun = DateTime.Now.AddDays(-1);
        if (Daily == "true")
                                {
                                    //DateTime currentTime = DateTime.Now;
                                    
                                    //int intervalToElapse = 0;
                                    //DateTime scheduleTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23, 59, 59, 999);
    
                                    //if (currentTime <= scheduleTime)
                                    //    intervalToElapse = (int)scheduleTime.Subtract(currentTime).TotalSeconds;
                                    //else
                                    //    intervalToElapse = (int)scheduleTime.AddDays(1).Subtract(currentTime).TotalSeconds;
    
                                    //_DailyTimer = new System.Timers.Timer(intervalToElapse);
                                    //if (_DailyTimer.Interval == 0)
                                    //{
                                    if (_lastRun.Date < DateTime.Now.Date)
                                    {
                                        DateTime schTime = new DateTime(_lastRun.Year, _lastRun.Month, _lastRun.Day, 23, 59, 59, 999);
                                        string tempFilename = Convert.ToString(tempDailyTime.TimeOfDay).Replace(":", "-") + ".xlsx";
                                        if (!File.Exists(tempDir + "\\Daily" + "\\" + ReportName + "_" + tempFilename))
                                        {
                                            GenerateDailyReport(ReportName, ReportID, ConnectionString, ReportColumnName, ReportBQuery,Convert.ToString(_lastRun.Date), Convert.ToString(schTime), tempDir + "\\Daily", tempFilename);
    _lastRun = DateTime.Now;
                                        }
                                    }
                                    //}
    
                                }
