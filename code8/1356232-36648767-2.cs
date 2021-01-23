    var list = from a in SpeechSynthesizer.AllVoices
           where a.Language.Contains("en")
           select a;
    if (list.Count() > 0)
    {
    synthesizer.Voice = list.Last();
    }
