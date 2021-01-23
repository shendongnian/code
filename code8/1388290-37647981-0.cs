    public void ParallelUpdate(List<Entity> targets)
    {
        try
        {
            this.Manager.ParallelProxy.Update(targets);
        }
        catch (AggregateException ae)
        {
            // Handle exceptions
        }
    }
