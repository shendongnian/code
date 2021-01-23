     private void OnChanged(object sender, FileSystemEventArgs e)
                    {
                        string emailMsg = "Loan Tape: " + e.Name + " is available for processing";
                        FileEventData fileEventData = new FileEventData()
                        {
                            FileName = e.Name,
                            Message = emailMsg,
                        };
                        this.fileEventDatas.Add(fileEventData);
                    }
     
