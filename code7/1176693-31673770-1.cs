    using (Process process = new Process())
                {
                    try
                    {
                        string arguments = "/F /T /IM {0}";
                        process.StartInfo.FileName = "taskkill";
                        process.StartInfo.Arguments = string.Format(arguments, processName); ;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        StringBuilder output = new StringBuilder();
                        StringBuilder error = new StringBuilder();
                        using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                        using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                        {
                            process.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data == null)
                                {
                                    outputWaitHandle.Set();
                                }
                                else
                                {
                                    output.AppendLine(e.Data);
                                }
                            };
                            process.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data == null)
                                {
                                    errorWaitHandle.Set();
                                }
                                else
                                {
                                    error.AppendLine(e.Data);
                                }
                            };
                            process.Start();
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();
                            if (process.WaitForExit(timeout) &&
                                outputWaitHandle.WaitOne(timeout) &&
                                errorWaitHandle.WaitOne(timeout))
                            {
                                if (process.ExitCode == 0)
                                    // Success Message
                            }
                            else
                            {
                                // Fail Message
                            }
                        }
                        if (!string.IsNullOrEmpty(output.ToString()))
                           //Out put
                        if (!string.IsNullOrEmpty(error.ToString()))
                            //Error out put
                    }
                    catch (Exception ex)
                    {
                        Comments = ex.Message;
                        //Exception logging
                    }
                }
