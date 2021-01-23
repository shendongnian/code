    // Reset start to zero if start was not trimmed at all, and compensate length
    if (clipOffsetOriginalFrames == 0)
    {
        OffsetAdjusterFrames = 2;
        DurationAdjusterFrames = -2;
    }
    // Reset start to zero if start had been trimmed by just 1 frame, and compensate length
    else if (clipOffsetOriginalFrames == 1)
    {
        OffsetAdjusterFrames = 1;
        DurationAdjusterFrames = -1;
    }
    else
    {
        OffsetAdjusterFrames = 0;
        DurationAdjusterFrames = 0;
    }
