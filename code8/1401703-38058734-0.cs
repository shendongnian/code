    public List<CHECKLIST> GetAllComplaintsCount()
    {
        try
        {
            return _context.Checklists
                .GroupBy(a => a.MonitorEnteredEmpID)
                .Select(a => new CHECKLIST { Amount = a.Sum(b =>b.MonitorEnteredEmpID), Name = a.Key })
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Could not get am with checklist", ex);
            return null;
        }
    }
