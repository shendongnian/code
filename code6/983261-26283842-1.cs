    GrammarBuilder thisIsPhrase = new GrammarBuilder("This is");
    Choices choices = new Choices("Dog, Cat");
    GrammarBuilder endPhrase = new GrammarBuilder(choices);
    Choices both = new Choices(new GrammarBuilder[] { thisIsPhrase, endPhrase });
     Grammar dictationGrammar = new Grammar((GrammarBuilder)both);
