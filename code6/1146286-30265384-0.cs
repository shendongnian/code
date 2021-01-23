	// We can provide a frame offset so that each frame has a time that it's supposed to be
	// seen at. This ensures that the video looks correct if the render rate is lower than
	// the frame rate, since these times will be used (it'll be choppy, but at least it'll
	// be paced correctly -- necessary so that sound won't go out of sync).
	long currentTick = DateTime.Now.Ticks;
	StartTick = StartTick ?? currentTick;
	var frameOffset = new TimeSpan(currentTick - StartTick.Value);
	// Figure out if we need to render this frame to the file (ie, has enough time passed
	// that this frame will be in the file?). This prevents us from going over the
	// desired frame rate and improves performance (assuming that we can go over the frame
	// rate).
	double elapsedTimeInSeconds = stopwatch.ElapsedTicks / (double) Stopwatch.Frequency;
	double timeBetweenFramesInSeconds = 1.0 / FrameRate;
	if (elapsedTimeInSeconds >= timeBetweenFramesInSeconds)
	{
		stopwatch.Restart();
		Writer.WriteVideoFrame(frame.ToBitmap(), frameOffset);
	}
