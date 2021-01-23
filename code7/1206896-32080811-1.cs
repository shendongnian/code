    private string CreateXamlFromRTB()
        {
            string xamlText = null;
            TextRange tr = new TextRange(editor.mainRTB.Document.ContentStart, editor.mainRTB.Document.ContentEnd);
            MemoryStream ms = new MemoryStream();
            tr.Save(ms, DataFormats.Xaml);
            xamlText = Encoding.ASCII.GetString(ms.ToArray());
                //xamlText = ASCIIEncoding.Default.GetString(ms.ToArray());
           
            return xamlText;
        }
