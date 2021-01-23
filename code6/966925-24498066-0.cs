    using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
    {
        // show installed voices
        foreach (var v in synthesizer.GetInstalledVoices().Select(v => v.VoiceInfo))
        {
            Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
              v.Description, v.Gender, v.Age);
        }
    
        // select male senior (if it exists)
        synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
    
        // select audio device
        synthesizer.SetOutputToDefaultAudioDevice();
    
        // build and speak a prompt
        PromptBuilder builder = new PromptBuilder();
        builder.AppendText("Found this on Stack Overflow.");
        synthesizer.Speak(builder);
    }
