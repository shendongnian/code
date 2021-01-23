	public ITargetBlock<Client.InputRecord> BuildDefaultFinalActions()
	{
		var splitter = new BroadcastBlock<Client.InputRecord>(null);
		var getresults = new TransformManyBlock(...);    // propagator
		var saveinput = new ActionBlock(...);
		var saveresults = new ActionBlock(...);
		splitter.LinkTo(saveinput, PropagateCompletion);
		splitter.LinkTo(getresults, PropagateCompletion);
		getresults.LinkTo(saveresults, PropagateCompletion);
		return new Util.EncapsulatedTarget<Client.InputRecord>(splitter, Task.WhenAll(saveinput.Completion, saveresults.Completion));
	}
