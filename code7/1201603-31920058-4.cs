    private async Task ProduceConsumeAsync()
    {
        var taskProducer = ProduceAsync();
        // while the producer is busy producing, you can start the consumer:
        var taskConsumer = ConsumeAsync();
        // while both tasks are busy, you can do other things,
        // like keep the UI responsive
        // after a while you need to be sure the tasks are finished:
        await Task.WhenAll(new Task[] {taskProducer, taskConsumer});
    }
