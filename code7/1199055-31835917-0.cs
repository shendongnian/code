    public byte[] Convert(string source, string commandLocation)
            {
                Process p;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = commandLocation;
                psi.WorkingDirectory = @"D:\" ;// Path.GetDirectoryName(psi.FileName);
    
                // run the conversion utility
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
    
                // note: that we tell wkhtmltopdf to be quiet and not run scripts
                string args = "-q -n ";
                args += "--disable-smart-shrinking ";
                args += "";
                args += "--outline-depth 0 ";
                args += "--page-size A4 ";
                args += " - -";
    
                psi.Arguments = args;
    
                p = Process.Start(psi);
    
                try
                {
                    using (StreamWriter stdin = p.StandardInput)
                    {
                        stdin.AutoFlush = true;
                        stdin.Write(source);
                    }
    
                    //read output
                    byte[] buffer = new byte[32768];
                    byte[] file;
                    using (var ms = new MemoryStream())
                    {
                        while (true)
                        {
                            int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);
                            if (read <= 0)
                                break;
                            ms.Write(buffer, 0, read);
                        }
                        file = ms.ToArray();
                    }
    
                    p.StandardOutput.Close();
                    // wait or exit
                    p.WaitForExit(60000);
    
                    // read the exit code, close process
                    int returnCode = p.ExitCode;
                    p.Close();
    
                    if (returnCode == 0)
                        return file;
                    else
                        LogManager.Log("Could not create PDF, returnCode:" + returnCode);
                }
                catch (Exception ex)
                {
                    LogManager.Log("Could not create PDF", ex);
                }
                finally
                {
                    p.Close();
                    p.Dispose();
                }
                return null;
            }
