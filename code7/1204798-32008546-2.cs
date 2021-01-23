    private void LoadRecord(int intID)
    {
        using (Context context = new Context())
        {
            var graph = context.CareCoordinators
            .Where(c => c.CareCoordinatorId.Equals(intID))
            .Include("DefaultAreas")
            .Include("Branch")
            .ToList();
            _Subject = graph[0];
        }
    }
