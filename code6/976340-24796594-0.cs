    private static readonly Dictionary<string, Func<IWorkerJob>> workerJobFactories = new Dictionary<string, Func<IWorkerJob>>
    {
        {WorkerJobType.IMPORT_GOOGLE_JOB, () => new ImportGoogleJob()},
        {WorkerJobType.IMPORT_XYZ_JOB, () => new ImportXyzJob()}
        ...
    };
    private static IComparable GetWorkerJob(string type)
    {
        Func<IComparable> factory = null;
        if (workerJobFactories.TryGetValue(type, out factory))
        {
            return factory();
        }
        return null;
    }
