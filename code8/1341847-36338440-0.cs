    public IEnumerable<Complaints> GetAll()
    {
        try
        {
            return _context.Complaints
                .Include(t => t.MONITORINGs)
                        .ThenInclude(t3=>t3.MONITORINGNotes )
                .OrderBy(t => t.FileNum)
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError("Could not get complaint with checklist", ex);
            return null;
        }
    }
