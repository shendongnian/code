    [Area("Exporting")]
    [Route("api/ImportExport")]
    public class ImportExportController : Controller
    {
      ............
      [Route("GeneratePDF")]
     [HttpPost]    
     public void GeneratePDFFFromHtml(string designId, string strData)
    {           
    SubmittedForm sf = new SubmittedForm();
    string schema = requestSchema;
    customer_DbConnection db = new customer_DbConnection();
    RenderFormController renderController = new RenderFormController();
    renderController.GeneratePdf(strData, db, sf);
    //return RedirectToAction(model.DesignId, "Prdocut/Edit");       
    }
    
    .......
