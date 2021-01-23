        var processingBlocks = new Dictionary<string, ActionBlock<Request>>();
        var splitterBlock = new ActionBlock<Request>(request =>
        {
            ActionBlock<Request> processingBlock;
            if (!processingBlocks.TryGetValue(request.Id, out processingBlock))
            {
                processingBlock = processingBlocks[request.Id] =
                    new ActionBlock<Request>(r => /* process the request here */);
            }
            processingBlock.Post(request);
        });
