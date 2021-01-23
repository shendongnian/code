    public void exportPDF(string fileName, string Orientation, string html)
    {
        try
        {
            HtmlToPdfConverter pdf = new HtmlToPdfConverter();
            html = html.Replace("\n", "");
            html = html.Replace("\t", "");
            html = html.Replace("\r", "");
            html = html.Replace("\"", "'");
            switch (Orientation)
            {
                case "Portrait":
                    pdf.Orientation = PageOrientation.Portrait;
                    break;
                case "Landscape":
                    pdf.Orientation = PageOrientation.Landscape;
                    break;
                default:
                    pdf.Orientation = PageOrientation.Default;
                    break;
            }
            pdf.Margins.Top = 25;
            pdf.PageFooterHtml = createPDFFooter();
            var pdfBytes = pdf.GeneratePdf(createPDFScript() + html + "</body></html>");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".pdf");
            HttpContext.Current.Response.BinaryWrite(pdfBytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        catch
        {
            //if you have other exceptions you'd like to trap for, you can filter or throw them here
            //otherwise, just ignore your Response.End() exception.
        }
    }
