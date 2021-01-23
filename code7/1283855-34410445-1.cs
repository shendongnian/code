    class Program
    {
        private static bool eventHandled;
        private static int elapsedTime;
        static void Main(string[] inputArgs)
        {
            string args = string.Empty;
            try
            {
                Process exeProcess = new Process();
                exeProcess.StartInfo.CreateNoWindow = false;
                exeProcess.StartInfo.UseShellExecute = false;
                exeProcess.StartInfo.FileName = "abc.exe";
                exeProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                exeProcess.StartInfo.Arguments = args;
                exeProcess.EnableRaisingEvents = true;
                exeProcess.Exited +=  OnProcessExited;
                exeProcess.Start();
            }
            catch (Exception ex)
            {
                // Log error.
                Console.WriteLine(ex.Message);
            }
            // Wait for Exited event, but not more than 30 seconds.
            const int SLEEP_AMOUNT = 100;
            while (!eventHandled)
            {
                elapsedTime += SLEEP_AMOUNT;
                if (elapsedTime > 30000)
                {
                    break;
                }
                Thread.Sleep(SLEEP_AMOUNT);
            }
        }
        private static void OnProcessExited(object sender, EventArgs eventArgs)
        {
            // do your work here   
            eventHandled = true;
        }
    }
