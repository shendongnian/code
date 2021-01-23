    private Segment lastSegment;
    public void UpdateFrame()
    {
        Segment currentSegment = MovePlayer();
        if (currentSegment != lastSegment)
        {
            // Handle player entering the new segment here
            lastSegment = currentSegment;
        }
    }
    private Segment MovePlayer()
    {
        // if up-button is pressed, then move up and so on
        // Then find and return the current segment
    }
