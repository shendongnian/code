        private void DoWork()
                    {
                        //control for shutdown using a flag
                        while (true)
                        {
                            if (fileEventDatas.Count > 0)
                            {
                                FileEventData data;
                                fileEventDatas.TryTake(out data);
                                SendMessage(serverName + " DFC: Loan Tape Available", data.Message, this.email_distribution);
                                eventLogger.WriteEntry("DFC Loan Tape available");
                            }
                        }
                     }
    
