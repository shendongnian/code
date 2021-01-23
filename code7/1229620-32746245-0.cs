    class Program
    {
        static void Main(string[] args)
        {
            string fullPath = @"C:\Perl64\bin\perl.exe";
            string arguments = @"C:\Users\Desktop\old.pl"+"aa" + "bb";
            Process myProcess = Process.Start(fullPath, arguments);
            myProcess.WaitForExit(999);
            if (!myProcess.HasExited)
            {
                myProcess.Kill();
                throw new Exception("Timed out while running process");
            }
            Console.WriteLine("all set");
            Console.ReadKey();
        }
    }
