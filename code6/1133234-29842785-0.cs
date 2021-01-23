    Word objWord = new Word(); //Your object;
    Meaning objMeaning = new Meaning();
    Example objExample = new Example();
    var tupleModel = new Tuple<Word, Meaning, Example>(objWord, objMeaning, objExample);
    return View(tupleModel); 
