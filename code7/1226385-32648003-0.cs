    public static decimal MaxValue<T>(IEnumerable<T> myCol) where T : IMyInterface
    {
        decimal max = myCol.First().Amount;
       // then iterate collection to find max value, code ommitted
    }
