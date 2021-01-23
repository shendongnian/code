        // Part 1 - Connect to Media Services
      //          Setup upload progress event
      //          Upload a video to encode
      CloudMediaContext mediaContext =
        new CloudMediaContext("[ ACCOUNT NAME ]","[ ACCOUNT KEY ]");
      mediaContext.Assets.OnUploadProgress += Assets_OnUploadProgress;
      var asset = mediaContext.Assets.Create(    
        @"C:\windows\Performance\WinSat\winsat.wmv");
      // Part 2 - Create a task, specify encoding details
      Console.Clear();
      IJob job = mediaContext.Jobs.CreateJob("Sample Job");
      var expressionEncoder = mediaContext.MediaProcessors.Where(
        mp => mp.Name == "Expression Encoder").Single();
      var task = job.Tasks.Add(
        mediaProcessor: expressionEncoder,
        configuration: "H.264 HD 720p VBR");
      task.Inputs.Add(asset);
      task.Outputs.Add("Sample Task Output Asset");
      // Part 3 - Submit the encoding job to begin processing
      while (job.State != JobState.Finished)
      {
        job = mediaContext.Jobs.Refresh(job.Id);
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Job Name: " + job.Name);
        Console.WriteLine("Job ID: " + job.Id);
        Console.WriteLine();
        Console.WriteLine("Job State: {0,-20}", job.State);
        Console.WriteLine("Task Progress: {0:0.00}%  ",
          job.Tasks.Single().Progress);
        Thread.Sleep(500);
      }
      Console.WriteLine();
      Console.WriteLine("Job Complete!");
      Console.ReadLine();
    }
