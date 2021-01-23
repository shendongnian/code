    states = {INPUT, TV, WATER};
    inputGrammar = createInputGrammar();
    tvGrammar = createTvGrammar();
    waterGrammar = createWaterGrammar();
    state = INPUT;
    vodi onRecognitionResult() {
    
       if (state == INPUT) {
            if (result == "TV") {
                state = TV;
                recognizer.loadGrammar(tvGrammar);
            }
       }
       if (state == TV) {
            if (result == "Volume UP") {
                raiseVolume();
            }
            if (result == "TV done") {
                state = INPUT;
                recognizer.loadGrammar(inputGrammar);
            }
        }
        // Restart recognition
        recognizer.recognizeAsync();
    }
