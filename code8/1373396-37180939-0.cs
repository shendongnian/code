    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
        namespace TestWindowService
        {
            public static class MyLogger
            {
                public static void WriteErrorLog(Exception ex)
                {
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                        sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                        sw.Flush();
                        sw.Close();
                    }
                    catch
                    {
                    }
                }
        
                public static void WriteErrorLog(string Message)
                {
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                        sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                        sw.Flush();
                        sw.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }
