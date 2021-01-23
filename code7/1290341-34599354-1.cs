    public async void Fun()
    {
        var local = ApplicationData.Current.LocalFolder;
        var scriptFile = await local.CreateFileAsync("script.py", CreationCollisionOption.ReplaceExisting);
        using (var stream = await scriptFile.OpenStreamForWriteAsync())
        using (var writer = new StreamWriter(stream))
        {
            await writer.WriteLineAsync(@"print ""Hello, World!""");
        }
        var proxyFile = await local.CreateFileAsync("script.py.python-proxy", CreationCollisionOption.ReplaceExisting);
        await Launcher.LaunchFileAsync(proxyFile);
        var resultPath = "script.py.python-proxy-result";
        var counter = 0;
        IStorageItem resultFile = null;
        while (resultFile == null)
        {
            if (counter != 0)
            {
                if (counter++ > 5)
                    throw new Exception();
                await Task.Delay(250);
            }
            resultFile = await local.TryGetItemAsync(resultPath);
        }
        try
        {
            using (var mutex = new Mutex(true, "PythonProxy Mutex")) { }
        }
        catch (AbandonedMutexException) { }
        using (var stream = await local.OpenStreamForReadAsync(resultPath))
        using (var reader = new StreamReader(stream))
        {
            var content = await reader.ReadToEndAsync();
            var dialog = new MessageDialog(content);
            await dialog.ShowAsync();
        }
        await scriptFile.DeleteAsync();
        await proxyFile.DeleteAsync();
        await resultFile.DeleteAsync();
    }
