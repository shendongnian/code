    private void button1_Click(object sender, EventArgs e)
    {
        using (SpeechSynthesizer synth = new SpeechSynthesizer())
        {
            // Configure the audio output
            synth.SetOutputToDefaultAudioDevice();
            // Build a prompt
            PromptBuilder builder = new PromptBuilder();
            builder.AppendText("That is a big pizza!");
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                // Select voice
                synth.SelectVoice(info.Name);
                // Speak the prompt
                synth.Speak(builder);
            }
        }
    }
