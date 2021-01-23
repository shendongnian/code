	class Program
		{
			private static SpeechRecognitionEngine sre;
			static void Main(string[] args)
			{
				NaoSpeechRecognitionEntities db = new NaoSpeechRecognitionEntities();
				var userInput = db.UserInputs.ToList();
				//List<string> userReplies = new List<string>();
				Choices userReplies = new Choices();
				foreach (var reply in userInput)
				{
					userReplies.Add(reply.Reply);
				}
			sre = new SpeechRecognitionEngine();
			GrammarBuilder gb = new GrammarBuilder();
			gb.Append(userReplies);
			Grammar g = new Grammar(gb);
			sre.LoadGrammar(g);
			sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
			sre.SetInputToDefaultAudioDevice();
			// Start recognition.
			sre.Recognize();
            Console.ReadKey();
		}
		static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			
			CurrentReply.currentReply = e.Result.Text;
			sre.Recognize();
		}
