    reader.SpeakAsyncCancelAll();
    while (reader.State == SynthesizerState.Speaking)
    {
          Application.DoEvents();
    }
    // reader.SetOutputToNull();
    AudioStream.Flush();
    AudioStream.Close();
