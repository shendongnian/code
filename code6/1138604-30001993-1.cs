    public static async Task<bool> SomeButNotAllAsync<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, CancellationToken cancel)
    {
      if(source == null)
        throw new ArgumentNullException("source");
      if(predicate == null)
        throw new ArgumentNullException("predicate");
      cancel.ThrowIfCancellationRequested();
      return await source.
        Select(predicate)
        .Distinct()
        .Take(2)
        .CountAsync(cancel)
        .ConfigureAwait(false) == 2;
    }
    public static Task<bool> SomeButNotAllAsync<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
    {
      return source.SomeButNotAllAsync(predicate, CancellationToken.None);
    }
