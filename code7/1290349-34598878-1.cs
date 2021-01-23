        var templateRegex = new Regex("\\[templateForWords\\]");
        var wordPlacementRegex = new Regex("\\[word\\]");
        var translationPlacementRegex = new Regex("\\[translation]\\]");
    
        using (var document = WordprocessingDocument.Open(stream, true))
        { 
          MainDocumentPart mainPart = document.MainDocumentPart;
         
          // do your work here...
          var paragraphTemplate = mainPart.Document.Body
           .Descendants<Paragraph>()
           .Where(p=>templateRegex.IsMatch(p.InnerText)); //pseudo 
           //... or whatever gives you the text of the Para, I don't have the SDK right now
         
          foreach (string word in YourDictionary){
            var paraClone = paragraphTemplate.Clone(); // pseudo 
      
    // you may need to do something like 
    // paraClone.Descendents<Text>().Where(t=>regex.IsMatch(t.Value))
    // to find the exact element containing template text
            paraClone.Text = templateRegex.Replace(paraClone.Text,"");// pseudo 
            paraClone.Text = wordPlacementRegex.Replace(paraClone.Text,word);
            paraClone.Text = translationPlacementRegex.Replace(paraClone.Text,YourDictionary[word]);
             
            paragraphTemplate.Parent.InsertAfter(paraClone,ParagraphTemplate); // pseudo
          }
        
          paragraphTemplate.Remove();
        
          // document should auto-save 
          document.Package.Flush();
        }
