    IEnumerable<T> Get(int maxBatchCount, int getMessageTimeout, int getBatchTimeout)
    {
        var result = new List<T>();
        var startTime = DateTime.Now;
        while (result.Count < maxBatchCount)
        {
            var deliverEventArgs = new BasicDeliverEventArgs();
            if ((_consumer as QueueingBasicConsumer).Queue.Dequeue(GetMessageTimeout, out deliverEventArgs))
            {
                var entry = ContractSerializer.Deserialize<T>(deliverEventArgs.Body);
                result.Add(entry);
                _queue.Channel.BasicAck(deliverEventArgs.DeliveryTag, false);
            }
            else
                break;
            if ((DateTime.Now - startTime) >= TimeSpan.FromMilliseconds(getBatchTimeout))
                break;
        }
        return result;
    }
