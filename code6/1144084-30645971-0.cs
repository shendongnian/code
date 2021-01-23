            var proc = new System.Diagnostics.Process();
            String path = "";
            var pathArray = System.Windows.Forms.Application.StartupPath.Split('\\');
            for (int i = 0; i < pathArray.Count() - 1; i++)
            {
                path += pathArray[i] + "\\";
            }
            path = path + "fileName.EXE";
            proc.StartInfo.FileName = path;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("No Response from Scanner Screen!", "ERROR!");
                return;
            }
