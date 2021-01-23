        public static void RunBtnProcessThread(string processName, String sArgs, Button btn)
        {
            // disable the button until we release the newly launched process
            btn.Enabled = false;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = processName;
            startInfo.Arguments = sArgs;
            try
            {
                _ProcessMine = Process.Start(startInfo);
                _ProcessMine.EnableRaisingEvents = true;
                _ProcessMine.Exited += (sender, e) =>
                {
                    btn.Invoke((MethodInvoker)delegate { 
                        btn.Enabled = true; 
                    });
                    _ProcessMine = null;
                };
            }
            catch (Exception ex)
            {
                string _Funk = ReflectionHelper.GetMethodFullName(MethodBase.GetCurrentMethod());
                // error
                Debug.Assert(false, "Error: " + ex.Message);
                // Log error.
                TraceUtil.LogException(_Funk, ex);
            }
        }
