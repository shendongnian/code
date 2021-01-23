    void worker_DoWork2(object sender, DoWorkEventArgs e)
            {
                System.Diagnostics.Process.Start("app.exe", "!#@$$$!");
                
            }
    
    public void metroButton2_Click(object sender, EventArgs e)
            {
                var worker2 = new BackgroundWorker();
                worker2.DoWork += new DoWorkEventHandler(worker_DoWork2);
                worker2.RunWorkerAsync();
    
                Thread.Sleep(1000);
    
                String strDLLName = "spd.dll";
                String strProcessName = "app";    
                Int32 ProcID = GetProcessId(strProcessName);
                if (ProcID >= 0)
                {
                    IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, 1, ProcID);
                    if (hProcess == null)
                    {
                        return;
                    }
                    else
                    {
                        InjectDLL(hProcess, strDLLName);
                    }  
                }
                Application.Exit();
            }
