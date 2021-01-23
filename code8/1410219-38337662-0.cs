	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Web.Mvc;
	using Ionic.Zip;
	namespace MvcTesting.Controllers
	{
		public class HomeController : Controller
		{
			// GET: Home
			public ActionResult Index()
			{
				// replace C:\PickAFolderWithSomeFiles\ with a folder that has some files that you can zip to test
				List<string> files = System.IO.Directory.GetFiles(@"C:\PickAFolderWithSomeFiles\").ToList();
				using (ZipFile zip = new ZipFile())
				{
					foreach (string file in files)
						zip.AddFile(file, string.Empty);
					using (MemoryStream output = new MemoryStream())
					{
						zip.Save(output);
						return File(output.ToArray(), "application/zip", "file.zip");
					}
				}
			}
		}
	}
