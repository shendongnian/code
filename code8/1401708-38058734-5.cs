    public Dictionary<int, int> GetAllComplaintsCount()
    {
        try
        {
            return _context.Checklists
                .GroupBy(a => a.MonitorEnteredEmpID)
                .ToDictionary(g => g.Key, g => g.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError("Could not get am with checklist", ex);
            return null;
        }
    }
