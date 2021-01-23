    public void engine_WordsRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        Riconoscimento _riconoscimento = new Riconoscimento();
        _riconoscimento.loadWords();
        List<Word> words = _riconoscimento.GetList();
        var cmd = words.Where(c => c.Text == e.Result.Text).First();
    }
