    Use this
    
    Helper for Style
    
    internal static class ItextPDFStyleHelper
        {
            internal static StyleSheet ApplyStyleSheetToHtml()
            {
                var styles = new StyleSheet();
                styles.LoadTagStyle("body", "font-family", "Arial");
                styles.LoadTagStyle("table", "width", "95%");
                styles.LoadTagStyle("table", "font-size", "14px");
                styles.LoadTagStyle("table", "letter-spacing", ".004em");
                styles.LoadTagStyle("table", "border", "1");
                styles.LoadTagStyle("table", "border-spacing", "0px");
                styles.LoadTagStyle("table", "border-collapse", "collapse");
    
                styles.LoadTagStyle("td", "border", "1");
                styles.LoadTagStyle("td", "border-spacing", "0");
                styles.LoadTagStyle("td", "border-collapse", "collapse");
    
                styles.LoadTagStyle("th", "text-align", ".004em");
                styles.LoadTagStyle("th", "color", "1px solid black;");
                styles.LoadTagStyle("th", "bgcolor", "#f5a843");
                styles.LoadTagStyle("th", "border", "1");
                styles.LoadTagStyle("th", "border-spacing", "0");
                styles.LoadTagStyle("th", "border-collapse", "collapse");
    
                styles.LoadStyle("travel", "text-align", "center");
                styles.LoadStyle("travel", "Color", "black;");
                styles.LoadStyle("travel", "font-weight", "bold");
                styles.LoadStyle("travel", "bgcolor", "#f5a843");
                styles.LoadStyle("travel", "border", "1");
                styles.LoadStyle("travel", "border-spacing", "0");
                styles.LoadStyle("travel", "border-collapse", "collapse");
                return styles;
            }
        }
    
    To get FileStream
    
                MemoryStream memStream = new MemoryStream();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=PrintCalendar.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                FontFactory.RegisterDirectories();
                var styles = ItextPDFStyleHelper.ApplyStyleSheetToHtml();
                StringReader sr = new StringReader(printcalendarData);
                foreach (var element in HTMLWorker.ParseToList(sr, styles))
                {
                    pdfDoc.Add(element);
                }
                pdfDoc.Close();
                Response.Write(pdfDoc);
                memStream.WriteTo(Response.OutputStream);
    
                memStream.Position = 0;
    
                var file = File(memStream, "application/pdf");
                Response.End();
                return file;
