        string[] files = System.IO.Directory.GetFiles("c:\temp", "*.txt", System.IO.SearchOption.TopDirectoryOnly);
        foreach(string file in files)
        {
            if (System.DateTime.UtcNow.Subtract(System.IO.File.GetCreationTimeUtc(file)).TotalMinutes > 5)
                System.Diagnostics.Debug.WriteLine("TODO: Alert, file older than 5 minutes...");
        }
