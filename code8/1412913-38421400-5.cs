    public class ReadSpeech
    {
        public static bool _voiceChoice = true;
        // Performs synthesis
        async Task<IRandomAccessStream> SynthesizeTextToSpeechAsync(string text)
        {
            IRandomAccessStream stream = null;
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                if (temp.SettingsPartViewModel.UseVoiceSelection == true)
                {
                    VoiceInformation voiceInfo =
                      (
                        from voice in SpeechSynthesizer.AllVoices
                        where voice.Gender == VoiceGender.Female
                        select voice
                      ).FirstOrDefault() ?? SpeechSynthesizer.DefaultVoice;
                    synthesizer.Voice = voiceInfo;
                    stream = await synthesizer.SynthesizeTextToStreamAsync(text);
                }
                else
                {
                    VoiceInformation voiceInfo =
                      (
                        from voice in SpeechSynthesizer.AllVoices
                        where voice.Gender == VoiceGender.Male
                        select voice
                      ).FirstOrDefault() ?? SpeechSynthesizer.DefaultVoice;
                    synthesizer.Voice = voiceInfo;
                    stream = await synthesizer.SynthesizeTextToStreamAsync(text);
                }
            }
            return (stream);
        }
