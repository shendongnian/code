    public ActionResult Speak(string text)
    {
    var speech = new SpeechSynthesizer();
    speech.Speak(text);
    byte[] bytes;
    using (var stream = new MemoryStream())
    {
        speech.SetOutputToWaveStream(stream);
        bytes = stream.ToArray();
    }
    return File(bytes, "audio/x-wav");
    }
