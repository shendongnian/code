     process.StartInfo.FileName = _soxExePath;
     process.StartInfo.Arguments = _task.Arguments.RemoveFirstOccurence("sox");
     process.StartInfo.UseShellExecute = false;
     process.StartInfo.RedirectStandardOutput = true;
     process.StartInfo.RedirectStandardError = true;
     process.EnableRaisingEvents = true;
      //<set event handlers here>
     process.Exited += // define what to do to clear up
     process.Start();
