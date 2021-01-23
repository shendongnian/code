    using (Ajax.BeginForm("Financing_Product_Feature_Upload", "FileUpload", new { productid = @ViewBag.Product_ID }, new AjaxOptions() { HttpMethod = "POST" }, new { enctype = "multipart/form-data" }))
                            {
                                @Html.AntiForgeryToken()
                                <input type="file" name="files">   <input type="submit" value="Upload File to Server">
                            }
    public class FileUploadController : Controller
        {
        [HttpPost]
            public ActionResult Financing_Product_Feature_Upload(HttpPostedFileBase  files, string productid)
            { 
        // Action code goes here
        }
    }
