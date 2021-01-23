    public ActionResult BuildPdf(YourModel model)
    {
        // Return view if there is an error
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        // Render view output to string
        var report = RenderViewToString(this, "BuildPdf", model, "BuildPdf");
        // Convert string to PDF using ABCpdf
        var pdfBytes = PdfForHtml(report);
        // Return file result
        return File(pdfBytes, 
                    System.Net.Mime.MediaTypeNames.Application.Pdf,     
                    "Your_PDF_File_Name_Here.pdf");
        }
    }
