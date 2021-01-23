    foreach (var letter in vocabulary.Keys.OrderByDescending(c=>c)){
      // in reverse order because the copy range comes after the template range
      var pageTemplate = DuplicateRange(wordDocument,"\\[/?page\\]");
      
      foreach (var p in pageTemplate.OfType<OpenXmlCompositeElement>()){
       
        ReplaceTag(p, "[TitleLetter]",""+letter);
        var pageBr = ReplaceTag(p, "[pageBreak]","");
        if (pageBr.Any()){
          foreach(var pbr in pageBr){
           pbr.InsertAfterSelf(PageBreakPara.CloneNode()); 
          }
        }
        var wordTemplateFound = FindElements(p, "\\[/?WordTemplate\\]");
        if (wordTemplateFound .Any()){
           foreach (var word in vocabulary[letter].Keys){
              var wordTemplate = DuplicateRange(p, "\\[/?WordTemplate\\]")
                  .First(); // since it's a single paragraph template
              ReplaceTag(wordTemplate, "\\[/?WordTemplate\\]","");
              ReplaceTag(wordTemplate, "\\[Word]",word);
              ReplaceTag(wordTemplate, "\\[Translation\\]",vocabulary[letter][word]);
           }
        }
      }
    }
