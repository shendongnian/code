    private void Invoke()
    {
        for (int i = I; Condition.Invoke(i); i += Increment)
        {
            try
            {
                Action.Invoke(i);
            }
            catch (BreakException)
            { break; }
        }
    }
