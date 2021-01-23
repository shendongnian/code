    TransformBlock<string,DownloadResult> download_block =
        new TransformBlock<string, DownloadResult>(
            url => DownloadFile(url),
            new ExecutionDataflowBlockOptions
            {
                //Only 10 asynchronous download operations
                //can happen at any point in time.
                MaxDegreeOfParallelism = 10
            });
    TransformBlock<DownloadResult, ProcessingResult> process_block =
        new TransformBlock<DownloadResult, ProcessingResult>(
            dr => ProcessDownloadResult(dr),
            new ExecutionDataflowBlockOptions
            {
                //We limit the number of CPU intensive operation
                //to the number of processors in the system.
                MaxDegreeOfParallelism = Environment.ProcessorCount
            });
    download_block.LinkTo(process_block);
    foreach(var url in urls)
    {
        download_block.Post(url);
    }
