    var arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
                FontFactory.Register(arialFontPath);
                BaseFont bf = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font FontAr = new iTextSharp.text.Font(bf);
                iTextSharp.text.FontFactory.RegisterDirectory(arialFontPath);
    StyleSheet styles = new StyleSheet();
                styles.LoadTagStyle(HtmlTags.DIV, HtmlTags.FONTSIZE, "16");
                styles.LoadTagStyle(HtmlTags.DIV, HtmlTags.COLOR, "navy");
                styles.LoadTagStyle(HtmlTags.DIV, HtmlTags.FONTWEIGHT, "bold");
                styles.LoadTagStyle(HtmlTags.P, HtmlTags.INDENT, "30px");
                styles.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Arial Unicode MS");
                styles.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);
     List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(htmlText), styles);
                    for (int k = 0; k < htmlarraylist.Count; k++)
                    {
                        pdfDocument.Add((IElement)htmlarraylist[k]);
                    }
