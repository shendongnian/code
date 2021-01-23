    public async Task<string> RecognizeSpeech()
    {
      SpeechRecognizer recognizer = new SpeechRecognizer();
      SpeechRecognitionTopicConstraint topicConstraint = new SpeechRecognitionTopicConstraint(SpeechRecognitionScenario.Dictation, "Message");
      recognizer.Constraints.Add(topicConstraint);
      await recognizer.CompileConstraintsAsync();
      SpeechRecognitionResult result = await recognizer.RecognizeWithUIAsync();
      if (result.Confidence == SpeechRecognitionConfidence.High || result.Confidence == SpeechRecognitionConfidence.Medium)
      {
        return result.Text;
      }
      return null;
    }
