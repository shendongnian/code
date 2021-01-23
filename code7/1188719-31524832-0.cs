        private string runBatchGetSvnUrl()
        {
            System.Diagnostics.ProcessStartInfo psi =
              new System.Diagnostics.ProcessStartInfo(@"C:\getSvnUrl.bat");
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            System.Diagnostics.Process listFiles;
            listFiles = System.Diagnostics.Process.Start(psi);
            System.IO.StreamReader myOutput = listFiles.StandardOutput;
            listFiles.WaitForExit(2000);
            if (listFiles.HasExited)
            {
                string output = myOutput.ReadToEnd();
                return output;
            }
            else
            {
                return "It didn't work.";
                //change this to throw an excetion later
                
            }
            
        }
