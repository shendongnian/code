            class InfoForDownload
            {
                  public string FileName {get; set;}
                  public int FileSize {get; set;}
            }
            int fileSizeFromCheck;
            InfoForDownload info = new InfoForDownload() { FileName = "C:\Users\TheUser\OneDrive\Documents\etc\etc\backup.sql", FileSize = THEFILESIZEOFTHEFILEONEXTERNAL };
            BackgroundWorker checkDownload = new BackgroundWorker();
            checkDownload.WorkerReportsProgress = true;
            checkDownload.ProgressChanged += checkDownload_ProgressChanged;
            checkDownload.DoWork += checkDownload_DoWork;
            checkDownload.RunWorkerAsync(info);
            void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                  BackgroundWorker checkDownload = (sender as BackgroundWorker);
                  if (e.Argument != null)
                  {
                        InfoForDownload info = (sender as InfoForDownload);
                        ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                        cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                        cmdStartInfo.RedirectStandardOutput = true;
                        cmdStartInfo.RedirectStandardError = true;
                        cmdStartInfo.RedirectStandardInput = true;
                        cmdStartInfo.UseShellExecute = false;
                        cmdStartInfo.CreateNoWindow = true;
                        while(info.FileSize > fileSizeFromCheck){
                              Process cmdProcess = new Process();
                              cmdProcess.StartInfo = cmdStartInfo;
                              cmdProcess.ErrorDataReceived += cmd_Error;
                              cmdProcess.OutputDataReceived += cmd_DataReceived;
                              cmdProcess.EnableRaisingEvents = true;
                              cmdProcess.Start();
                              cmdProcess.BeginOutputReadLine();
                              cmdProcess.BeginErrorReadLine();
                              cmdProcess.StandardInput.WriteLine("for %I in (info.FileName) do @echo %~zI");
                              cmdProcess.StandardInput.WriteLine("exit");
                              cmdProcess.WaitForExit();
                              Thread.Sleep(200);
                              Console.WriteLine("The size of the file is " + fileSizeFromCheck + " " + (info.FileSize / fileSizeFromCheck  * 100) + "%");
                              checkDownload.ReportProgress(info.FileSize / fileSizeFromCheck  * 100);
                        }
                        
                  }
            }
            void checkDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                  progressBar.Value = e.ProgressPercentage;
            }
            static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
            {
                  Console.WriteLine("Output from other process");
                  Console.WriteLine(e.Data);
                  Int32.TryParse((e.Data / 1024) / 1024, out fileSizeFromCheck);
            }
