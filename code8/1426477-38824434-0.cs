    _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(AlarmClock_SpeechRecognized);
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmAM))));
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmPM))));
        
    if (Settings.Default.AClockEnbl == true)
            { AlarmTimer.Enabled = true; }
