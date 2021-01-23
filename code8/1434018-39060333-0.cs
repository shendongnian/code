	using (var synth = new SpeechSynthesizer())
	{
		var voices = synth.GetInstalledVoices().Dump();
		var male = voices.FirstOrDefault(v => v.VoiceInfo.Gender == VoiceGender.Male);
		if (male != null)
		{
			synth.SelectVoice(male.VoiceInfo.Name);
		}
		synth.Speak("Hello");
	}
