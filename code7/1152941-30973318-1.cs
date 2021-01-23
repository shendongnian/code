        private void terminateAll()
        {
            foreach (var i in pids)
            {
                try
                {
                    Process p = Process.GetProcessById(i);
                    p.Kill();
                }
                catch (Exception ex)
                {
                    //throw exception if we close the mstsc manually
                }
            }
        }
