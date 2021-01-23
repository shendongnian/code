    public ActionResult ExtractReceipt()
    {
        var getOwner = rentdb.OwnerRegs.Where(a => a.username == 
        User.Identity.Name).FirstOrDefault();
        var getId = getOwner.serial;
        ReportDocument rd = new ReportDocument();
        rd.Load(Path.Combine(Server.MapPath("~/Reports/Invoice.rpt")));
        rd.SetDataSource(rentdb.Invoices.Where(a => a.owner_id == getId).ToList()); //FirstOrDefault() Need To Change
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        stream.Seek(0, SeekOrigin.Begin);
        return File(stream, "application/pdf", "MyReceipt.pdf");
    }
