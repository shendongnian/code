	[HttpGet]
	public ActionResult GenericForm()
	{
		return new DownloadFileAsAttachmentResult(@"GenericForm.pdf", @"\Content\files\GenericForm.pdf", "application/pdf");
	}
    
    public class DownloadFileAsAttachmentResult : ActionResult
    {
		private string _filenameWithExtension { get; set; }
		private string _filePath { get; set; }
		private string _contentType { get; set; }
		// false = prompt the user for downloading;  true = browser to try to show the file inline
		private const bool DisplayInline = false;
		
		public DownloadFileAsAttachmentResult(string FilenameWithExtension, string FilePath, string ContentType)
		{
			_filenameWithExtension = FilenameWithExtension;
			_filePath = FilePath;
			_contentType = ContentType;
		}
		public override void ExecuteResult(ControllerContext context)
		{
			HttpResponseBase response = context.HttpContext.Response;
			response.Buffer = false;
			response.ContentType = _contentType;
			response.AddHeader("Content-Disposition", "attachment; filename=" + _filenameWithExtension); // force download
			response.AddHeader("X-Content-Type-Options", "nosniff");
			response.TransmitFile(_filePath);
		}
	}
