    foreach (var block in richTextBlock.Blocks)
    {
        var paragraph = block as Paragraph;
        if (paragraph != null)
        {
            var runCollection = paragraph.Inlines.Where(x => x is Run).Cast<Run>().ToList();
            foreach (var inline in runCollection)
            {
                        
            }
        }
    }
