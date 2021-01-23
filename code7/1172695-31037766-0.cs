    namespace Automate_Script
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime today =  DateTime.Today;
                // display today's date in console window.
                Console.WriteLine("\n\t\tToday is {0}", today.ToString("d"));
                
                if (!FileContainsDate(@"C:\MyScripts\weekDates.txt", today))
                    return; // Todays date not present in week dates, nothing shall be done.
    
                if (FileContainsDate(@"C:\MyScripts\monthDates.txt", today))
                {
                    RunScript("monthTest.bat");
                }
                else
                {
                    RunScript("weekTest.bat");
                }
    
                Console.ReadLine();
            }
    
            private static bool FileContainsDate(string dateFile, DateTime date)
            {
                try
                {
                    string[] dates = File.ReadAllLines(dateFile);
                    return dates.Any(line => Convert.ToDateTime(line) == date);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false; 
                }
            }
    
            private static void RunScript(string scriptFile)
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.WorkingDirectory = @"C:\MyScripts";
                    p.StartInfo.FileName = scriptFile;
                    p.StartInfo.CreateNoWindow = false;
                    p.Start();
                    p.WaitForExit();
                    System.Threading.Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred: {0}, {1}", ex.Message, ex.StackTrace.ToString());
                }
            }
        }
    }
