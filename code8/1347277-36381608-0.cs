    using (SpeechSynthesizer synth = new SpeechSynthesizer())
    {
        foreach (InstalledVoice voice in synth.GetInstalledVoices())
        {
            VoiceInfo info = voice.VoiceInfo;
            Console.WriteLine("Voice Name: " + info.Name);
        }
    }
