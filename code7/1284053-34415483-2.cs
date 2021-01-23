        [TestMethod]
        public async Task ProcessBots()
        {
            string[] bots = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            BroadcastBlock<string> getBotsBlock = new BroadcastBlock<string>(bot => bot, new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = ExecutionDataflowBlockOptions.Unbounded });
            Random rand = new Random();
            ActionBlock<string> processBotsBlock = new ActionBlock<string>(async bot =>
            {
                await Task.Delay(rand.Next(100, 1000));
                TestContext.WriteLine(bot);
            }, new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = ExecutionDataflowBlockOptions.Unbounded });
            ActionBlock<string> processBotsToLowerBlock = new ActionBlock<string>(async bot =>
            {
                await Task.Delay(rand.Next(100, 1000));
                TestContext.WriteLine(bot.ToLower());
            }, new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = ExecutionDataflowBlockOptions.Unbounded });
            getBotsBlock.LinkTo(processBotsBlock, new DataflowLinkOptions(){PropagateCompletion = true});
            getBotsBlock.LinkTo(processBotsToLowerBlock, new DataflowLinkOptions() { PropagateCompletion = true });
            foreach (var bot in bots)
                getBotsBlock.Post(bot);
            getBotsBlock.Complete();
            await processBotsBlock.Completion;
            await processBotsToLowerBlock.Completion;
        }
    Test Name:	ProcessBots
    Test Outcome:	Passed
    Result StandardOutput:	
    TestContext Messages:
    c
    A
    G
    B
    f
    b
    e
    F
    C
    a
    d
    g
    E
    D
