        string lastSpeechInput;
        static void listen_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var talk = new SpeechSynthesizer();
            switch (e.Result.Text) {
                case "Search Stock Symbol":
                    talk.Speak("What symbol?");
                    break;
            }
            if (stockSymbols.Contains(e.Result.Text) && lastSpeechInput == "Search Stock Symbol") {
                talk.Speak(getStockPrice(e.Result.Text);
                break;
            }
            lastSpeechInput = e.Result.Text;
        }
