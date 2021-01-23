    static void Main(string[] args)
            {
                // Log file creation
                var strDestopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                strDestopPath += "\\Diagnostic_Today.txt";
                var w = File.AppendText(strDestopPath);
    
                var commands = new ConcurrentBag<string>();
                //List<String> commands = new List<String>();
                commands.Add("nslookup www.google.com");
                commands.Add("Tracert -d  www.apple.com");
                commands.Add("ipconfig /all");
                commands.Add("ping www.google.com -n 10");
                commands.Add("nslookup www.apple.com");
    
                var results = new ConcurrentBag<Tuple<string, string>>();
    
                Parallel.ForEach(commands, cmd => {
                    new Test_Con(results).runCommand(cmd);
                });
    
    
                //Your results are here:
                foreach (var result in results)
                {
                    Console.WriteLine("Command: {0}",result.Item1);
                    Console.WriteLine("OutPut: {0}",result.Item1);
                    Console.WriteLine("----------------------------");
                }
    
                Console.ReadLine();
            }
        }
    
        public class Test_Con
        {
            static string d = null;
            private ConcurrentBag<Tuple<string, string>> results;
            private string command;
    
            public Test_Con(ConcurrentBag<Tuple<string, string>> results)
            {
                this.results = results;
            }
    
            public void runCommand(string command)
            {
                this.command = command;
                string starttime;
                string endtime;
    
                //* Create your Process
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c" + command;
    
                starttime = "Started at " + DateTime.Now + "\n";
    
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                //* Set your output and error (asynchronous) handlers
                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //* Start process and handlers
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
    
                process.WaitForExit();
                endtime = "Completed at " + DateTime.Now + "\n";
    
                d += "========================================================================";
                d += starttime + endtime;
    
                Console.WriteLine(d);
            }
            void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                //* Do your stuff with the output (write to console/log/StringBuilder)
                Console.WriteLine(outLine.Data); //This will keep writing all the command output irrespective    
    
                results.Add(new Tuple<string, string>( command, outLine.Data ));
            }
    
        }
