    static void Main(string[] args)
	{
		_completed = new ManualResetEvent(false);
		SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
		_recognizer.LoadGrammar(new Grammar(new GrammarBuilder("test")) Name = { "testGrammar" }); // load a grammar
		_recognizer.LoadGrammar(new Grammar(new GrammarBuilder("exit")) Name = { "exitGrammar" }); // load a "exit" grammar
		_recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
		_recognizer.SetInputToDefaultAudioDevice(); // set the input of the speech recognizer to the default audio device
		_recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous
		_completed.WaitOne(); // wait until speech recognition is completed
		_recognizer.Dispose(); // dispose the speech recognition engine
	}
	
	void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
	{
		 if (e.Result.Text == "test") // e.Result.Text contains the recognized text
		 {
			 Console.WriteLine("The test was successful!");
		 } 
		 else if (e.Result.Text == "exit")
		 {
			 _completed.Set();
		 }
	}
