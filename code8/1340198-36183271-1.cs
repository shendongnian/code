    private async Task Send()
    {
        try
        {
            var entities = GetAllEntities();
            foreach (var group in entities.GroupBy(r => r.Priority))
            {
                var tasks = group
                    .Select(entity => manager.SendEntity(entity))
                    .ToArray();
                var results = await Task.WhenAll(tasks);
                if (results.All(result => result))
                {
                    // some code here...
                }
            }
        }
        catch (Exception e)
        {
            logger.FatalException(e.Message, e);
        }
        finally
        {
            logger.Info("End...");
        }
    }
