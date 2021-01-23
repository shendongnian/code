    internal override void InnerInvoke()
    {
        // Get and null out the antecedent.  This is crucial to avoid a memory
        // leak with long chains of continuations.
        var antecedent = m_antecedent;
        Contract.Assert(antecedent != null, 
            "No antecedent was set for the ContinuationTaskFromTask.");
        m_antecedent = null;
