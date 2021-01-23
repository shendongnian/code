		public class Controller : System.Web.Mvc.Controller
		{
			public FileContentResult PdfFileResult(string viewPath, object model = null)
			{
				List<PdfPageContent> content = new List<PdfPageContent>();
				content.Add(new PdfPageContent() { Location = PdfPageLocation.Footer, Alignment = Element.ALIGN_LEFT, Content = "FOOTER LEFT" });
				content.Add(new PdfPageContent() { Location = PdfPageLocation.Footer, Alignment = Element.ALIGN_RIGHT, Content = "FOOTER RIGHT" });
				content.Add(new PdfPageContent() { Location = PdfPageLocation.Header, Alignment = Element.ALIGN_LEFT, Content = "HEADER LEFT" });
				content.Add(new PdfPageContent() { Location = PdfPageLocation.Header, Alignment = Element.ALIGN_RIGHT, Content = "HEADER RIGHT" });
				return new FileContentResult(RazorPdf.GeneratePdf(RenderViewToString(viewPath, model), content), "application/pdf");
			}
			public bool SavePdfFileResult(string viewPath, string relativeFilePath, object model = null)
			{
				byte[] data = RazorPdf.GeneratePdf(RenderViewToString(viewPath, model));
				if (!string.IsNullOrWhiteSpace(relativeFilePath))
				{
					try
					{
						System.IO.File.WriteAllBytes(Server.MapPath(relativeFilePath), data);
					}
					catch (Exception e)
					{ //In case of exception, file write has failed
						return false;
					}
					return true;
				}
				return false;
			}
			public string RenderViewToString(string viewPath, object model = null, bool partial = false)
			{
				ViewEngineResult viewEngineResult = partial ? ViewEngines.Engines.FindPartialView(ControllerContext, viewPath) :
					ViewEngines.Engines.FindView(ControllerContext, viewPath, null);
				if (viewEngineResult == null)
					throw new FileNotFoundException("View cannot be found.");
				var view = viewEngineResult.View;
				ControllerContext.Controller.ViewData.Model = model;
				string result = null;
				using (var sw = new StringWriter())
				{
					var ctx = new ViewContext(ControllerContext, view, ControllerContext.Controller.ViewData, ControllerContext.Controller.TempData, sw);
					view.Render(ctx, sw);
					result = sw.ToString();
				}
				return result;
			}
		}
