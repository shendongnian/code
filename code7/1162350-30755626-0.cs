     if (openFile.CheckFileExists)
        {
          range = new TextRange(rtfMain.Document.ContentStart, rtfMain.Document.ContentEnd);
          using (var fStream = new StreamReader(originalfilename, Encoding.Default,true))
          {
            range.Text = fStream.ReadToEnd();
          }
        }
