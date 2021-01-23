    //As sampleSentences are List of strings 
    var newListOfSentences = new List<SampleSentence>();
        
    foreach (string value in sampleSentences)
    	{
            var newSentence = new SampleSentence();
            newSentence.Text  = value ;
            //and the others...
    	    newListOfSentences.Add(newSentence);
    	}
