    SpeechSynthesizer synth = new SpeechSynthesizer();
    
    // Add a handler for the SpeakProgress event.
    synth.SpeakProgress += 
    new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);
    
    // Write each word and its character position to the console.
    static void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
    {
      Console.WriteLine("Speak progress: {0} {1}", e.CharacterPosition, e.Text);
    }
