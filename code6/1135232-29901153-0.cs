    IEnumerable<EMetrics> IEmetricsRepository.GetAllByProgram(params int[] programIds)
    {
        var metrics = EntitySet.Where(x => programIds.Contains(x.Programs.Select(y=>y.ID))).ToList();
        return metrics;
    }
