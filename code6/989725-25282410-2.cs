    using System.Web.Mvc;
    using test1.Models;
    using PagedList.Mvc;
    using PagedList;
    namespace test1.Controllers
    {
        public class UploadController
        {
            [HttpPost]
            public ActionResult DeleteItem(List<UploadItem> uploadItems)
            {
                UploadHelper.DeleteFileFromDirectory(uploadItems[0].FileName,
                uploadItems[0].Directory);
                var listOfUploadedFiles = UploadHelper.GenerateListOfUploads();
                const int rows = 5;
	            const int page = 1;
                int index = page.HasValue ? Convert.ToInt32(page) : 1;
                var uploadedFiles = listOfUploadedFiles.ToPagedList(index, rows);
                ViewBag.UploadedItems = uploadedFiles;
                ViewBag.PageNum = page;
                return View(uploadedFiles);
            }
        }
    }
