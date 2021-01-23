    /// <summary>
    /// Executes the task. This method will only be called once, and handles bookeeping associated with
    /// self-replicating tasks, in addition to performing necessary exception marshaling.
    /// </summary>
    private void Execute()
    {
        if (IsSelfReplicatingRoot)
        {
            ExecuteSelfReplicating(this);
        }
        else
        {
            try
            {
                InnerInvoke();
            }
            catch (ThreadAbortException tae)
            {
                // Don't record the TAE or call FinishThreadAbortedTask for a child replica task --
                // it's already been done downstream.
                if (!IsChildReplica)
                {
                    // Record this exception in the task's exception list
                    HandleException(tae);
 
                    // This is a ThreadAbortException and it will be rethrown from this catch clause, causing us to 
                    // skip the regular Finish codepath. In order not to leave the task unfinished, we now call 
                    // FinishThreadAbortedTask here.
                    FinishThreadAbortedTask(true, true);
                }
            }
            catch (Exception exn)
            {
                // Record this exception in the task's exception list
                HandleException(exn);
            }
        }
    }
