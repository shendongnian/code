    private RecognizerInfo GetRecognizer(string culture, string recognizerId)
    {
      try
      {
        foreach (var recognizer in SpeechRecognitionEngine.InstalledRecognizers())
        {
          if (!culture.Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase)) continue;
          if (!string.IsNullOrWhiteSpace(recognizerId))
          {
            string value;
            recognizer.AdditionalInfo.TryGetValue(recognizerId, out value);
            if ("true".Equals(value, StringComparison.OrdinalIgnoreCase))
              return recognizer;
          }
          else
            return recognizer;
        }
      }
      catch (Exception e)
      {
        log.Error(m => m("Recognizer not found"), e);
      }
      return null;
    }
    private void InitializeSpeechRecognizer(string culture, string recognizerId, Func<Stream> audioStream)
    {
      log.Debug(x => x("Initializing SpeechRecognizer..."));
      try
      {
        var recognizerInfo = GetRecognizer(culture, recognizerId);
        if (recognizerInfo != null)
        {
          recognizer = new SpeechRecognitionEngine(recognizerInfo.Id);
          //recognizer.LoadGrammar(VoiceCommands.GetCommandsGrammar(recognizerInfo.Culture));
          recognizer.LoadGrammar(grammar);
          recognizer.SpeechRecognized += SpeechRecognized;
          recognizer.SpeechRecognitionRejected += SpeechRejected;
          if (audioStream == null)
          {
            log.Debug(x => x("...input on DefaultAudioDevice"));
            recognizer.SetInputToDefaultAudioDevice();
          }
          else
          {
            log.Debug(x => x("SpeechRecognizer input on CustomAudioStream"));
            recognizer.SetInputToAudioStream(audioStream(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
          }
        }
        else
        {
          log.Error(x => x(Properties.Resources.SpeechRecognizerNotFound, recognizerId));
          throw new Exception(string.Format(Properties.Resources.SpeechRecognizerNotFound, recognizerId));
        }
        log.Debug(x => x("...complete"));
      }
      catch (Exception e)
      {
        log.Error(m => m("Error while initializing SpeechEngine"), e);
        throw;
      }
    }
