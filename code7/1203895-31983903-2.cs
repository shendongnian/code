    TextBlock tb = new TextBlock();
    Paragraph para = new Paragraph();
    para.FontSize = 25;
    para.FontWeight = FontWeights.Bold;
    para.Inlines.Add(new Run("new paragraph"));
    Span span = new Span(para.ContentStart, para.ContentEnd);
    span.FontWeight = para.FontWeight;
    span.FontSize = para.FontSize;
    tb.Inlines.Add(span);
