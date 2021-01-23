    public Dictionary<int, int> GetAllComplaintsCount(Int64 dateTicks)
        {
            try
            {
                var startDate = new DateTime(dateTicks);
                return _context.Checklists
                    .Where(a => a.COMPLAINT.Received_DT > startDate)
                    .GroupBy(a => a.MonitorEnteredEmpID)
                    .ToDictionary(g => g.Key, g => g.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get am with checklist", ex);
                return null;
            }
        }
