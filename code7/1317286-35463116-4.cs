    // Return the result of the hit test to the callback.
    public HitTestResultBehavior MyHitTestResult(HitTestResult result)
    {
        // Add the hit test result to the list that will be processed after the enumeration.
        hitResultsList.Add(result.VisualHit);
        // Set the behavior to return visuals at all z-order levels.
        return HitTestResultBehavior.Continue;
    }
