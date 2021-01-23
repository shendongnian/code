    // Create a formatted paragraph
            Paragraph para = new Paragraph();
            para.FontSize = 25;
            para.FontWeight = FontWeights.Bold;
            para.Inlines.Add(new Run("Text of paragraph."));
            Myrichtextboxtbx.Document.Blocks.Add(para);
