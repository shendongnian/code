	public static async Task ForEachAsync<TDocument>(
						this IAsyncCursor<TDocument> source, 
						Func<TDocument, int, Task> processor,
						CancellationToken cancellationToken = default(CancellationToken))
	{
		Ensure.IsNotNull(source, "source");
		Ensure.IsNotNull(processor, "processor");
		// yes, we are taking ownership... assumption being that they've
		// exhausted the thing and don't need it anymore.
		using (source)
		{
			var index = 0;
			while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
			{
				foreach (var document in source.Current)
				{
					await processor(document, index++).ConfigureAwait(false);
					cancellationToken.ThrowIfCancellationRequested();
				}
			}
		}
	}
