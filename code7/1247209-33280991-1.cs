     _nodeProcess.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
     _nodeProcess.Start();
     _nodeProcess.BeginOutputReadLine();
     var line = Console.ReadLine();
     while (line != null && line.ToLower() != "exit")
     {
          line = Console.ReadLine();
     }
     _nodeProcess.Close();
