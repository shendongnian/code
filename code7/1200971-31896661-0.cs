    void ProducingMethod()
    {
        var serviceABlock = new ActionBlock<YourInputObject>(o =>
        {
            serviceA.Call(o);
        });
        serviceABlock.Completion.ContinueWith(t =>
        {
            sendNotifyA();
        });
        var serviceBBlock = new ActionBlock<YourInputObject>(o =>
        {
            serviceB.Call(o);
        });
        serviceBBlock.Completion.ContinueWith(t =>
        {
            sendNotifyB();
        });
        var serviceCBlock = new ActionBlock<YourInputObject>(o =>
        {
            serviceC.Call(o);
        });
        serviceCBlock.Completion.ContinueWith(t =>
        {
            sendNotifyC();
        });
        foreach (var objectToProcess in queue)
        {
            if (SendToA)
            {
                serviceABlock.SendAsync(objectToProcess);
            }
            else if (SendToB)
            {
                serviceBBlock.SendAsync(objectToProcess);
            }
            else if (SendToC)
            {
                serviceCBlock.SendAsync(objectToProcess);
            }
        }
    }
