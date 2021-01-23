        using (var systeminfo= new Process
          {
            FileName = "systeminfo",
            RedirectStandardOutput = true,
            CreateNoWindow = false,
            UseShellExecute = false,
          })
        {
            systeminfo.Start();
            var result = systeminfo.StandardOutput.ReadToEnd();
            systeminfo.WaitForExit();
            return result;
        }
