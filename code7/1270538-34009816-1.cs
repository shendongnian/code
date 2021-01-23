    public async Task DoSomething(){
            bool done = false;
            Task.Run(ASYNC() =>
            {
                AWAIT Exporter.DoLongSyncTask();
            }).ContinueWith(r => done = true);
            StatusLabel = ".";
            while (!done)
            {
                if (StatusLabel == "")
                    StatusLabel = ".";
                else if (StatusLabel == ".")
                    StatusLabel = "..";
                else if (StatusLabel == "..")
                    StatusLabel = "";
                await Task.Delay(200);
            }
    }
