        public static bool FormatDrive_CommandLine(char driveLetter, string label = "", string fileSystem = "NTFS", bool quickFormat = true, bool enableCompression = false, int? clusterSize = null)
        {
            #region args check
 
            if (!Char.IsLetter(driveLetter) ||
                !IsFileSystemValid(fileSystem))
            {
                return false;
            }
 
            #endregion
            bool success = false;
            string drive = driveLetter + ":";
            try
            {
                var di                     = new DriveInfo(drive);
                var psi                    = new ProcessStartInfo();
                psi.FileName               = "format.com";
                psi.CreateNoWindow         = true; //if you want to hide the window
                psi.WorkingDirectory       = Environment.SystemDirectory;
                psi.Arguments              = "/FS:" + fileSystem +
                                             " /Y" +
                                             " /V:" + label +
                                             (quickFormat ? " /Q" : "") +
                                             ((fileSystem == "NTFS" && enableCompression) ? " /C" : "") +
                                             (clusterSize.HasValue ? " /A:" + clusterSize.Value : "") +
                                             " " + drive;
                psi.UseShellExecute        = false;
                psi.CreateNoWindow         = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput  = true;
                var formatProcess          = Process.Start(psi);
                var swStandardInput        = formatProcess.StandardInput;
                swStandardInput.WriteLine();
                formatProcess.WaitForExit();
                success = true;
            }
            catch (Exception) { }
            return success;
        }
