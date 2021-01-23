    Process ExternalProcess = new Process();
                    ExternalProcess.StartInfo.FileName = "ConsoleApplication.exe";
                    ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    ExternalProcess.Start();
                    ExternalProcess.WaitForExit();
