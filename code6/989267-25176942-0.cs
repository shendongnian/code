    public class DocumentResult : ActionResult
    {
	  private readonly Document document;
	  private readonly SaveOptions options;
	  public DocumentResult(Document document, SaveOptions options)
	  {
		this.document = document;
		this.options = options;
	  }
	
	  public override void ExecuteResult(ControllerContext context)
	  {
		this.document.Save(context.HttpContext.Response, "whatever", ContentDisposition.Inline, this.options);
	  }
    }
