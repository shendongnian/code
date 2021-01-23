    public ActionResult StandartPDF()
        {
            var makeCvSession = Session["makeCV"];
            var root = Server.MapPath("~/PDF/");
            var pdfname = String.Format("{0}.pdf", Guid.NewGuid().ToString());
            var path = Path.Combine(root, pdfname);
            path = Path.GetFullPath(path);
            var something = new Rotativa.ViewAsPdf("StandartPDF", makeCvSession) { FileName = "cv.pdf", SaveOnServerPath = path };
            return something;
        }
