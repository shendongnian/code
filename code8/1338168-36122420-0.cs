    public void Process(List<SomeObject> list)
    {
        ConcurrentBag<SomeDataOutput> cbOutput = new ConcurrentBag<SomeDataOutput>();
        ParallelOptions po = new ParallelOptions(){MaxDegreeOfParallelism=4};
        Parallel.ForEach(list, po, (objInput) =>
        {
            cbOutput.Add(GetOutputData(objInput));
        });
    }
