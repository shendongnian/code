        TextRange documentTextRange = new TextRange(RICHTEXTBOXNAME.Document.ContentStart, RICHTEXTBOXNAME.Document.ContentEnd);
        using (FileStream fs = File.Open(FILENAME, FileMode.Open))
        {
          documentTextRange.Load(fs, DataFormats.Rtf);
        }
