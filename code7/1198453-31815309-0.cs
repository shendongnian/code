    public async Task<List<RTClusterNode>> CrawlAndReturnNodesParrallelAsync(ProgressBar pBar)
    {
        IProgress<int> progress = new Progress<int>(n => pBar.Value = n);
        //Some processing done here
    
        int count = 0;
        Parallel.ForEach(clusterNodes_hr, node =>
        {
            foreach (var vm in node.VmList)
            {
                Console.WriteLine("Crawling VM: " + vm.VmName);
                VirtualMachineCrawler vmCrawler = new VirtualMachineCrawler(vm);
                vmCrawler.CrawlForDataDiskSpace();
                Interlocked.Increment(ref count);
                Console.WriteLine("Current count: " + count);
                progress.Report(count);
            }
        });
        return clusterNodes_hr;
    }
