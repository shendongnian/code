    using java.io;
    using java.util;
    using edu.stanford.nlp.ling;
    using edu.stanford.nlp.tagger.maxent;
    using Console = System.Console;
    using System.IO;
    using System.Windows.Forms;
    
    namespace Stanford.NLP.POSTagger.CSharp
    {
        class PosTagger
    
        {
            // get the base folder for the project
            public static string GetAppFolder()
            {
                return Path.GetDirectoryName(Application.ExecutablePath).Replace(@"*your project directory here*\bin\Debug", string.Empty);
            }
    
            public void testTagger()
            {
                var jarRoot = Path.Combine(GetAppFolder(), @"packages\stanford-postagger-2015-12-09");
                Console.WriteLine(jarRoot.ToString());
                var modelsDirectory = jarRoot + @"\models";
    
                // Loading POS Tagger
                var tagger = new MaxentTagger(modelsDirectory + @"\english-bidirectional-distsim.tagger");
    
                // Text for tagging
                var text = "A Part-Of-Speech Tagger (POS Tagger) is a piece of software that reads text"
                           + "in some language and assigns parts of speech to each word (and other token),"
                           + " such as noun, verb, adjective, etc., although generally computational "
                           + "applications use more fine-grained POS tags like 'noun-plural'.";
    
                var sentences = MaxentTagger.tokenizeText(new java.io.StringReader(text)).toArray();
                foreach (ArrayList sentence in sentences)
                {
                    var taggedSentence = tagger.tagSentence(sentence);
                    Console.WriteLine(Sentence.listToString(taggedSentence, false));
                }
            }
        }
    }
