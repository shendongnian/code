      var ctrl = new Xceed.Wpf.Toolkit.RichTextBox();
      foreach(var textToConvert in input)
      {
           ctrl.AppendText(textToConvert);
      }
      
      var doc = ctrl.Document;
      var content = new TextRange(doc.ContentStart, doc.ContentEnd);
      if (content.CanSave(DataFormats.Rtf))
      {
          using (var stream = new MemoryStream())
          {
              content.Save(stream, DataFormats.Rtf);
          }
      }
