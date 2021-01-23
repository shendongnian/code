     ProcessStartInfo start = new ProcessStartInfo();
     start.FileName = "path/to/python.exe";
     start.Arguments = string.Format("{0} {1}", cmd, args);
     start.UseShellExecute = false;
     start.RedirectStandardOutput = true;
     using(Process process = Process.Start(start))
     {
         using(StreamReader reader = process.StandardOutput)
         {
             string result = reader.ReadToEnd();
             Console.Write(result);
         }
     }
