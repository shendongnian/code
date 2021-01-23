    private static IEnumerable<object> GetProcessors()
    {
        yield return new ProcessorA();
        yield return new ProcessorB();
    }
    
    public static IEnumerable<Processor<X>> GetProcessors<X>() where X: ProcessorInfo
    {
        return GetProcessors.OfType<Processor<X>>();
    }
