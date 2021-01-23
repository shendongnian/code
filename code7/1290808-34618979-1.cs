    public IEnumerable<T> DuplicateRange<T>(OpenXmlCompositeElement root, string tagRegex)
      where T: OpenXmlElement
    { 
    // tagRegex must describe exactly two tags, such as [pageStart] and [pageEnd]
    // or [page] [/page] - or whatever pattern you choose
    
      var tagElements = FindElements(root, tagRegex);
      var fromEl = tagElements.First();
      var toEl = tagElements.Skip(1).First(); // throws exception if less than 2 el
       
    // you may want to find a common parent here
    // I'll assume you've prepared the template so the elements are siblings.
      
      var result = new List<OpenXmlElement>();
    
      var step = fromEl.NextSibling();
      while (step !=null && toEl!=null && step!=toEl){
       // another method called DeleteRange will instead delete elements in that range within this loop
        var copy = step.CloneNode();
        toEl.InsertAfterSelf(copy);
        result.Add(copy);
        step = step.NextSibling();
      }
     
      return result;
    }
    public IEnumerable<OpenXmlElement> ReplaceTag(OpenXmlCompositeElement parent, string tagRegex, string replacement){
      var replaceElements = FindElements<OpenXmlElement>(parent, tagRegex);
      var regex = new Regex(tagRegex);
      foreach(var el in  replaceElements){
         el.InnerText = regex.Replace(el.InnerText, replacement);
      }
    
      return replaceElements;
    }
