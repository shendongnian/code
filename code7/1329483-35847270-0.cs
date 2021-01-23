    public void DoReadViaTap(IRpc rpc, BlockingCollection<ArraySegment<byte>> bc)
    {
        Task.Factory.StartNew(async () =>
        {
            while (true)
            {
                byte[] result = await rpc.ReadAsync();
                if (result.Length > 0)
                {
                    bc.Add(new ArraySegment<byte>(result));
                }
                catch (AggregateException ignored)
                {
                }
            }
        }, TaskCreationOptions.LongRunning);
    }
