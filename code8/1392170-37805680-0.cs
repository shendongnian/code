    Paragraph par = section.AddParagraph();  
    par.Format.Alignment = ParagraphAlignment.Left;
    // Use formatted text to specify the color
    FormattedText ftext = new FormattedText();
    ftext.AddText("Coloured Text");
    ftext.Color = Colors.Red;
    par.AddText("normal Text");
    par.AddSpace(1);
    par.Add(ftext);
    par.AddSpace(1);
    par.AddText("rest of the normal Text");
