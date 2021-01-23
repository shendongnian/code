    public async Task DoReadViaTap(IRpc rpc, BlockingCollection<ArraySegment<byte>> bc)
    {
        while (true)
        {
            try
            {
                byte[] result = await rpc.ReadAsync().ConfigureAwait(false);
                if (result != null && result.Length > 0) // or result?.Length > 0 on C# 6
                {
                    bc.Add(new ArraySegment<byte>(result));
                }
            }
            catch (Exception ignored)
            {
            }
        }
    }
