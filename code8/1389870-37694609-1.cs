    string texto = "Dónde puedo conseguirlo";
    Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add();
    para1.Range.Text = texto;
    para1.Range.Font.Bold = 0;
    para1.Range.Font.Size = 11;
    para1.Range.Font.Name = "Arial";
    para1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
    para1.Range.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineNone;
    para1.Format.SpaceAfter = 0;
    /* select the range based on the word "puedo" */
    object start = texto.IndexOf("puedo");
    object end = texto.IndexOf("puedo") + "puedo".Length;
    Microsoft.Office.Interop.Word.Range rngBold = document.Range(ref start, ref end);
    rngBold.Bold = 1; // apply bold
    para1.Range.InsertParagraphAfter();
