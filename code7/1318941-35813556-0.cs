        foreach (Paragraph paragraph in tbText.Document.Blocks)
        {
            var sb = new StringBuilder();
            foreach (Run inline in paragraph.Inlines)
            {
                sb.Append(inline.Text);
            }
            editedTextes.Add(new TextBlock()
            {
               Text = sb.ToString(),
               TextWrapping = TextWrapping.NoWrap
            });
        }
