            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition:", "attachment;filename=" + _fileName + ".pdf");
            //  HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Write(pdfDoc);
