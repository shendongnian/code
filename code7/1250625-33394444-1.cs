    var workitems = Enumerable.Range(0, 1000000);
	workitems.AsParallel()
			 .AsOrdered()
			 .WithDegreeOfParallelism(16)
			 .WithMergeOptions(ParallelMergeOptions.NotBuffered)
			 .ForAll(i => { Thread.Slee(1000); Console.WriteLine(i); });
