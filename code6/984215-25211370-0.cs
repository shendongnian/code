    string attachment = "attachment; filename=" + Session["pdf_name"] + ".pdf";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/pdf";
    StringWriter s_tw = new StringWriter();
    HtmlTextWriter h_textw = new HtmlTextWriter(s_tw);
    h_textw.AddStyleAttribute("font-size", "8pt");
    h_textw.AddStyleAttribute("color", "Black");
    Panel1.RenderControl(h_textw);//Name of the Panel
    Document doc = new Document();
    PdfWriter.GetInstance(doc, Response.OutputStream);
    doc.Open();
    StringReader s_tr = new StringReader(s_tw.ToString());
    HTMLWorker html_worker = new HTMLWorker(doc);
    html_worker.Parse(s_tr);
    doc.Close();
    Response.Write(doc);
