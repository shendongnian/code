    if (currentUICulture == "ja-JP")
    {
        string colorsString = colors.Aggregate((first, Next) => (first += ";" + Next));
        string transColor = speak.Translate(colorsString, "en", "ja");
        string[] jaColors = transColor.Split(new char[]{';','、'});
        for (int i = 0; i < jaColors.Length; i++)
        {
            //
        }
        commands = new string[]{ "なし", "クリア", "イコール",
            "プラス", "マイナス", "掛ける", "分割", "追加" };
    }
    
    Choices commandsChoices = new Choices(commands);
    GrammarBuilder gb = new GrammarBuilder(commandsChoices);
    sr.LoadGrammar(new Grammar(gb));
    
    Choices colorChoices = new Choices(colors);
    gb = new GrammarBuilder(colorChoices);
    sr.LoadGrammar(new Grammar(gb));
    
    sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
    sr.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(sr_SpeechDetected);
    sr.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sr_SpeechRecognitionRejected);
