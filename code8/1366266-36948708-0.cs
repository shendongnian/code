    public async Task DoQuery(CancellationToken token) {
        await ctx.TableX.AsNoTracking().ForEachAsync(row =>
        {
             // process here
        }, token);
    }
