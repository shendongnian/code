    public async Task<FileContentResult> Speak(string text)
    {
        Task<FileContentResult> task = Task.Run(() =>
        {
            using (var synth = new System.Speech.Synthesis.SpeechSynthesizer())
            using (var stream = new MemoryStream())
            {
                synth.SetOutputToWaveStream(stream);
                synth.Speak(text);
                var bytes = stream.GetBuffer();
                return File(bytes, "audio/x-wav");
            }
        });
        return await task;
    }
