    analyzers = new[]{
         new Analyzer(){
             name = "my_default",
             type = "#Microsoft.Azure.Search.CustomAnalyzer",
             tokenizer = "standard",
             tokenFilters = new List<string>(){
                    "lowercase",
                    "asciifolding",
                    "phonetic",
                    "trim",
                    "my_edgeNGram" }
         },
    },
    tokenFilters = new[]{
         new EdgeNGramTokenFilter(){
              name = "my_edgeNGram",
              type = "#Microsoft.Azure.Search.EdgeNGramTokenFilter",
              minGram = 2,
              maxGram = 50}
         }
