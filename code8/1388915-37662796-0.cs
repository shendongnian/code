    private static void PrintDocument(string fileName)
        {
            var process = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "print",
                    FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe", //You could use an app config string here
                    Arguments = $@"/p /h {fileName}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            if (process.HasExited == false)
            {
                process.WaitForExit(10000);
            }
            process.EnableRaisingEvents = true;
            try
            {
                //Try to gracefully exit the process first
                var proccessIsClosed = process.CloseMainWindow();
                //If it doesn't gracefully close, kill the process
                if (!proccessIsClosed)
                {
                    process.Kill();
                }
            }
            catch
            {
                throw new Exception("Process ID " + process.Id +
                                               " is unable to gracefully close. Please check current running processes.");
            }
        }
