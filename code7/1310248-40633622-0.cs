    public UITestControl GetPreviousSibling(UITestControl uitc)
    {
        UITestControlCollection siblings = uitc.GetParent().GetChildren();
        // Note that 'sibings[0]' has no predecessor
        for (int ii=1; ii<siblings.Count)
        {
            if (uitc.Name == siblings[ii].Name)
            {
                return siblings[ii - 1];
            }
        }
        return null;
    }
