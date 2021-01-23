    if (Response.IsClientConnected)
    {
        if (pdfId == 0)
        {
            var model = _service.GetViewData(client, id);
            model.StaffName = CTCHelper.GetStaffName(model.StaffId);
            pdfId = _service.SavePDF(model, ControllerContext);
        }
        var data = _service.GetPDF(pdfId);
        var mimeType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "inline; filename=TESI.pdf");
        return File(data, mimeType);
    }
    Response.End();
    return new ViewResult();
