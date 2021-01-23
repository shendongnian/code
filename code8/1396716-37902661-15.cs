    var degreesOfParallelism = Environment.ProcessorCount; // Or another value
    var stepCount = 1000000000;
    var step = 1D/stepCount;
    var stopwatch = Stopwatch.StartNew();
    var partitionSize = stepCount/degreesOfParallelism;
    var tasks = Enumerable
      .Range(0, degreesOfParallelism)
      .Select(
        partition => {
          var count = partition < degreesOfParallelism - 1
            ? partitionSize
            : stepCount - (degreesOfParallelism - 1)*partitionSize;
          return Task.Run(() => ComputePartialSum(partition*partitionSize, count, step));
        }
      )
      .ToArray();
    Task.WaitAll(tasks);
    var sum = tasks.Sum(task => task.Result);
    stopwatch.Stop();
    var pi = step*sum;
