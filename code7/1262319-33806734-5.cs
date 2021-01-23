    public IEnumerable<string> GetUniqueBSentences(string a, string b)
    {
        // We can reuse these objects - they could be stored in member fields:
        ITokenizer tokenizer = new ClassicTokenizer(true);
        SentenceSegmenter segmenter = new TokenBasedSentenceSegmenter(tokenizer);
        NGramExtractor trigramExtractor = new NGramExtractor(3);
    
        IEnumerable<string> sentencesA = segmenter.GetSentences(a);
        IEnumerable<string> sentencesB = segmenter.GetSentences(b);
        
        ITokenizer wordTokenizer = new ClassicTokenizer(false);
        foreach (string sentenceB in sentencesB)
        {
            IList<string> wordsB = wordTokenizer.Tokenize(sentenceB);
            ISet<NGram> wordTrigramsB = trigramExtractor.ExtractAsSet(wordsB);
            
            bool foundMatchingSentence = false;
            foreach (string sentenceA in sentencesA)
            {
                // This will be repeated for every sentence in B. It would be more efficient
                // to generate trigrams for all sentences in A once, before we enter these loops:
                IList<string> wordsA = wordTokenizer.Tokenize(sentenceA);
                ISet<NGram> wordTrigramsA = trigramExtractor.ExtractAsSet(wordsA);
                
                if (wordTrigramsA.Intersect(wordTrigramsB).Any())
                {
                    // We found a sentence in A that shares word-trigrams, so stop comparing:
                    foundMatchingSentence = true;
                    break;
                }
            }
            
            // No matching sentence in A? Then this sentence is unique to B:
            if (!foundMatchingSentence)
                yield return sentenceB;
        }
    }
