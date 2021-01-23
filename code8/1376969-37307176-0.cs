    string imgHeader1 = "C:/image1.jpg";
    foreach (Word.Section section in document.Sections)
    {
        section.PageSetup.DifferentFirstPageHeaderFooter = -1;
        Word.HeaderFooter header = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
        //wdHeaderFooterFirstPage would be for first page..
        header.Range.ParagraphFormat.SpaceAfter = 96;
        header.Range.Text = "test";
        header.Shapes.AddPicture(imgHeader1, 0, 1, 0, -40, 120, 20);
    }
