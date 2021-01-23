    string destinationPath = "Sample.docx";
    string search = "@@name@@";
    string replace ="John Doe";
    
    using (var parent = WordprocessingDocument.Open(Path.GetFullPath(destinationPath), true))
    {
        foreach (var altChunk in parent.MainDocumentPart.GetPartsOfType<AlternativeFormatImportPart>())
        {
            if (Path.GetExtension(altChunk.Uri.OriginalString) != ".docx")
                continue;
    
            using (var child = WordprocessingDocument.Open(altChunk.GetStream(), true))
            {
                var foundText = child.MainDocumentPart.Document.Body
                    .Descendants<Text>()
                    .Where(t => t.Text.Contains(search))
                    .FirstOrDefault();
            
                if (foundText != null)
                {
                    foundText.Text = foundText.Text.Replace(search, replace);
                    break;
                }
            }
        }
    }
