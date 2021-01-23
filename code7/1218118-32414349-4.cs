    [HttpGet]
            public virtual ActionResult GetFile(string fileTemporary)
            {
                // ...preparing file path... init fileTemporary.
    
                var bytes = System.IO.File.ReadAllBytes(fileTemporary);
                var fileContent = new FileContentResult(bytes, "application/pdf");
                Response.AddHeader("Content-Disposition", "attachment; filename=\"YourFileName.pdf\"");
    
                return fileContent;
            }
