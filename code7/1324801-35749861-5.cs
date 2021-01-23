	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	namespace TestApp
	{
		class Program
		{
			/// <summary>
			/// TestApp.exe [hangtime(int)] [self-terminate(bool)]
			/// TestApp.exe kill --terminate all processes called TestApp
			/// </summary>
			/// <param name="args"></param>
			
			static void Main(string[] args)
			{
				int hangTime = 5; //5 second default
				bool selfTerminate = true;
				Process thisProcess = Process.GetCurrentProcess();
				if (args.Length > 0)
				{
					if (args[0] == "kill")
					{
						KillAllTestApps(thisProcess);
						return;
					}
					hangTime = int.Parse(args[0]);
					if (args.Length > 1)
					{
						selfTerminate = bool.Parse(args[1]);
					}
				}
				Console.WriteLine("{0} TestApp started", thisProcess.Id);
				Console.WriteLine("{0} Now going to make a horrible mess by calling myself in 1 second...", thisProcess.Id);
				if (selfTerminate)
				{
					Console.WriteLine("{0} !! I will self terminate after creating a child process to break the lineage chain", thisProcess.Id);
				}
				Thread.Sleep(1000);
				ExecutePostProcess("TestApp.exe", thisProcess, selfTerminate);
				if (selfTerminate)
				{
					Thread.Sleep(1000);
					Console.WriteLine("{0} !! Topping myself! PID {0}", thisProcess.Id);
					thisProcess.Kill();
				}
				Console.WriteLine("{0} TestApp is going to have a little 'sleep' for {1} seconds", thisProcess.Id, hangTime);
				Thread.Sleep(hangTime * 1000);
				Console.WriteLine("{0} Test App has woken up!", thisProcess.Id);
			}
			public static void ExecutePostProcess(string cmd, Process thisProcess, bool selfTerminate)
			{
				Console.WriteLine("{0} Creating Child Process cmd '{1}'", thisProcess.Id, cmd);
				var t = new Thread(delegate()
				{
					try
					{
						var processInfo = new ProcessStartInfo("cmd.exe", "/c " + cmd + " 10 " + (selfTerminate ? "false" : "true" ));
						processInfo.CreateNoWindow = true;
						processInfo.UseShellExecute = false;
						processInfo.RedirectStandardError = true;
						processInfo.RedirectStandardOutput = true;
						using (Process process = Process.Start(processInfo))
						{
							Console.WriteLine("{0} Created New Process {1}", thisProcess.Id, process.Id);
							process.EnableRaisingEvents = true;
							process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine(e.Data);
							process.BeginOutputReadLine();
						   
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				});
				t.Start();
				Console.WriteLine("{0} Finished Child-Threaded Process", thisProcess.Id);
			}
			/// <summary>
			/// kill all TestApp processes regardless of parent
			/// </summary>
			private static void KillAllTestApps(Process thisProcess)
			{
				Process[] processes = Process.GetProcessesByName("TestApp");
				foreach(Process p in processes)
				{
					if (thisProcess.Id != p.Id)
					{
						Console.WriteLine("Killing {0}:{1}", p.ProcessName, p.Id);
						p.Kill();
					}
				}
			}
		}
	}
