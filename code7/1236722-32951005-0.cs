    namespace AnswerOne
    {
        class Program
        {
            static void Main(string[] args)
            {
                //we use a prosessstartinfo 
                System.Diagnostics.ProcessStartInfo procInfo = new System.Diagnostics.ProcessStartInfo("rasdial.exe");
                procInfo.RedirectStandardError = true;
                //must be false
                procInfo.UseShellExecute = false;
                var process = new System.Diagnostics.Process();
                process.StartInfo = procInfo;
                process.Start();
                process.WaitForExit();
            
                string error = process.StandardError.ReadToEnd();
                //check if there is any error
                if (string.IsNullOrEmpty(error))
                {
                    System.Console.WriteLine(error);
                }
                System.Console.WriteLine("Press any key to close");
                System.Console.ReadLine();
            }
        }
    }
