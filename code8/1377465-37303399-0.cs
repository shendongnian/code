    using GalaSoft.MvvmLight.Messaging;
    public async Task<bool> ScanFolderAsync()
    {
         try
         {
            var ret = new List<DataListItem>();
            var files = Directory.EnumerateFiles(folder, filter, includeSubs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            await Task.Run(() => {
                    Parallel.ForEach(files, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, (file) =>
                {
                    var item = new DataListItem(file);
                    Messenger.Default.Send<DataListItem>(item);
                    this.files.Add(item);
                });
           });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
