    public static void Main()
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.FileName = "c:\\windows\\system32\\control.exe";
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
