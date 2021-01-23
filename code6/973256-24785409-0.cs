    Parallel.ForEach(Partitioner.Create(0, n * m), partition =>
        {
            for (int i = partition.Item1; i < partition.Item2; i++)
            {
                W[i] *= C[i];
            }
        });
