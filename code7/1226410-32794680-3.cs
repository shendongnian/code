       public byte[] SaveAllContent(RichTextBox rtb)
        {
            var content = new TextRange(rtb.Document.ContentStart, rtb_Main.Document.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                content.Save(ms, DataFormats.XamlPackage, true);
                return ms.ToArray();
            }
    
        }
    
        public void LoadAllContent(byte [] bd, RichTextBox rtb)
        {
            var content = new TextRange(rtb.Document.ContentStart, rtb_Main.Document.ContentEnd);
            MemoryStream ms = new MemoryStream(bd);
            content.Load(ms, System.Windows.DataFormats.XamlPackage);
        }
