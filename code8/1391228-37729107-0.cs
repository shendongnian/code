    Parallel.ForEach(trades, parallelOptions,
          // Loop Init
      () =>
      {
        // This creates one list per partition
        return new List<Result>(); // Becomes list
      },
          // Loop Body
      (trade, loopState, index, list) =>
      {
        // Only add the results to the local list for this partition
        list.Add(new Result());
        return list;
      },
          // Loop Completion
      list=>
      {
          lock (_lockObj)
          {
              // Merge the local list from each partition into the shared results list
              results.AddRange(list);
              Interlocked.Add(ref count, list.Count);
          }
      });
