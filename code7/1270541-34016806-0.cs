    using (var timer = new System.Windows.Forms.Timer())
    {
        timer.Tick += (s, e) =>
        {
            if (StatusLabel == "")
                StatusLabel = ".";
            else if (StatusLabel == ".")
                StatusLabel = "..";
            else if (StatusLabel == "..")
                StatusLabel = "";
        };
        timer.Interval = 100;
        timer.Enabled = true;
    
        await Task.Run(() => Exporter.DoLongSyncTask);
    }
