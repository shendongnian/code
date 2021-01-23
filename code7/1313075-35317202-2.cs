        while (!fileSaveTask.IsCompleted)
        {
            await Task.WhenAny( new Task[]
            {
                fileSaveTask,
                Task.Delay(TimeSpan.FromSeconds(1)),
            };
            if (!fileSaveTask.IsCompleted
               this.UpdateProgressWindow(...);
        }
