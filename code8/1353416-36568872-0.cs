    public async Task<string> DownloadAndExtractFile(string source, string destination, string ItemDownload, IProgress<int> progress)
    {
        // shortened for clarity
        await Task.Run(() =>
        {
            progress.Report(50);
            try
            {
                Process x = Process.Start(pro);
                Task.WaitAll();
                progress.Report(100);
                x.Close();
                Console.WriteLine("Extract Successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        });
        return "Success";
    }
