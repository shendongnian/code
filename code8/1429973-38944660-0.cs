    class Program
    {
        static void Main(string[] args)
        {
            RunPython();
            Console.ReadKey();
        }
        static  void RunPython()
        {
            var args = "test.py"; //main python script
            ProcessStartInfo start = new ProcessStartInfo();
            //path to Python program
            start.FileName = @"F:\Python\Python35-32\python.exe";
            start.Arguments = string.Format("{0} ",  args);
            //very important to use modules and other scripts called by main script
            start.WorkingDirectory = @"f:\labs";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
