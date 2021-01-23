    [HttpGet]
            public virtual ActionResult GetFile(string fileTemporary)
            {
                // ...preparing file path... init fileTemporary.
    
                var bytes = System.IO.File.ReadAllBytes(fileTemporary);
                var fileContent = new FileContentResult(bytes, "binary/octet-stream");
                Response.AddHeader("Content-Disposition", "attachment; filename=\"YourFileName.txt\"");
    
                return fileContent;
            }
